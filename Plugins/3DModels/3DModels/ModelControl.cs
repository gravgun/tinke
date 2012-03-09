﻿/*
 * Copyright (C) 2011  pleoNeX
 *
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>. 
 *
 * By: pleoNeX
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginInterface;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace _3DModels
{
    public partial class ModelControl : UserControl
    {
        IPluginHost pluginHost;
        sBMD0 model;
        sBTX0 tex;

        Dictionary<int, int> texturesGL;
        Dictionary<int, int> textureID;

        PolygonMode pm = PolygonMode.Fill;

        public ModelControl()
        {
            InitializeComponent();
        }
        public ModelControl(IPluginHost pluginHost, sBMD0 model)
        {
            InitializeComponent();
            this.label1.Parent = glControl1;
            this.pluginHost = pluginHost;
            this.model = model;
            this.tex = Get_BTX0();

            numericUpDown1.Maximum = model.texture.texInfo.num_objs;
            numericUpDown2.Maximum = model.model.mdlData[0].polygon.header.num_objs;
        }
        public ModelControl(IPluginHost pluginHost, sBMD0 model, sBTX0 tex)
        {
            InitializeComponent();
            this.label1.Parent = glControl1;
            this.pluginHost = pluginHost;
            this.model = model;
            this.tex = tex;

            numericUpDown1.Maximum = model.texture.texInfo.num_objs;
            numericUpDown2.Maximum = model.model.mdlData[0].polygon.header.num_objs;

        }
        private void ModelControl_Load(object sender, EventArgs e)
        {
            glControl1.Context.MakeCurrent(glControl1.WindowInfo);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Viewport(this.ClientRectangle);

            glControl1.SwapBuffers();
            LoadAllTex();
            ProcessBones();
        }

        private void LoadAllTex()
        {
            texturesGL = new Dictionary<int,int>();
            textureID = new Dictionary<int, int>();

            for (int i = 0; i < model.model.mdlData[0].material.texture.num_objs; i++)
            {
                sBMD0.Model.ModelData.Material.TexPalData texInfo = (sBMD0.Model.ModelData.Material.TexPalData)model.model.mdlData[0].material.texture.infoBlock.infoData[i];
                texturesGL.Add(texInfo.ID, LoadTextures(texInfo.ID));
                textureID.Add(texInfo.ID, i);
            }
        }
        private void ProcessBones()
        {
            for (int c = 0; c < model.model.mdlData[0].bones.commands.Count; c++)
            {
                sBMD0.Model.ModelData.Bones.Command cmd = model.model.mdlData[0].bones.commands[c];
                switch (cmd.command)
                {
                    case 0x44:
                    case 0x24:
                    case 0x04:
                        int currTex = 0;
                        if (texturesGL.ContainsKey(cmd.parameters[0]))
                            currTex = cmd.parameters[0];
                        else
                            texturesGL.TryGetValue(1, out currTex);
                        
                        model.model.mdlData[0].polygon.display[cmd.parameters[2]].materialAssoc = texturesGL[currTex];
                        model.model.mdlData[0].polygon.display[cmd.parameters[2]].materialID = textureID[currTex];
                        break;
                    default:
                        break;
                }
            }
        }

        private void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            
            GL.PushMatrix();    // For translation and scale

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Rotate(angleX, 0f, 1f, 0f);
            GL.Rotate(angleY, 0f, 0f, 1f);
            GL.Scale(distance, distance, distance);
            GL.Translate(x, y, z);
            label1.Text = "X: " + x.ToString() + " Y: " + y.ToString() + " Z: " + z.ToString() + "\r\n" +
                "AngleX: " + angleX.ToString() + " AngleY: " + angleY.ToString() + " Distance: " + distance.ToString();

            GL.Disable(EnableCap.Texture2D);
            // TODO: Draw box

            // Edges
            DrawEdges();

            //GL.DepthFunc(DepthFunction.Less);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(AlphaFunction.Greater, 0.5f);
            GL.Enable(EnableCap.Texture2D);
            GL.Disable(EnableCap.CullFace);
            GL.Enable(EnableCap.Dither);

            // Fix transparency problems
            //GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            //GL.AlphaFunc(AlphaFunction.Greater, 0.5f);
            //GL.Enable(EnableCap.AlphaTest);
            //GL.Disable(EnableCap.Blend);
            //GL.Enable(EnableCap.LineSmooth);
            //GL.Enable(EnableCap.PolygonSmooth);
            //GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.One);
            //GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusDstAlpha);
            //GL.Color4(1.0f, 1.0f, 1.0f, 0.5f);
            //GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.PolygonMode(MaterialFace.FrontAndBack, pm);

            GL.MatrixMode(MatrixMode.Texture);
            GL.LoadIdentity();

            GL.Color3(1.0f, 1.0f, 1.0f);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (int)TextureEnvMode.Replace);

            if (!checkBox1.Checked)
            {
                for (int i = 0; i < model.model.mdlData[0].polygon.header.num_objs; i++)
                {
                    sBMD0.Model.ModelData.Polygon.Display poly = model.model.mdlData[0].polygon.display[i];
                    sBTX0.Texture.TextInfo texInfo = (sBTX0.Texture.TextInfo)tex.texture.texInfo.infoBlock.infoData[poly.materialID];

                    GL.BindTexture(TextureTarget.Texture2D, poly.materialAssoc);
                    

                    GL.Scale(1.0f / (float)texInfo.width, 1.0f / (float)texInfo.height, 1.0f); // Scale the texture to fill the polygon
                    BMD0.GeometryCommands(poly.commands);
                }
            }
            else
            {
                int texInd = LoadTextures((int)numericUpDown1.Value);
                sBTX0.Texture.TextInfo texInfo = (sBTX0.Texture.TextInfo)tex.texture.texInfo.infoBlock.infoData[(int)numericUpDown1.Value];

                GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (int)TextureEnvMode.Replace);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                GL.BindTexture(TextureTarget.Texture2D, texInd);

                GL.PolygonMode(MaterialFace.FrontAndBack, pm);

                GL.MatrixMode(MatrixMode.Texture);
                GL.LoadIdentity();

                GL.Scale(1.0f / (float)texInfo.width, 1.0f / (float)texInfo.height, 1.0f); // Scale the texture to fill the polygon
                BMD0.GeometryCommands(model.model.mdlData[0].polygon.display[(int)numericUpDown2.Value].commands);
            }
            GL.MatrixMode(MatrixMode.Modelview);

            //GL.Disable(EnableCap.Texture2D);
            //GL.Disable(EnableCap.AlphaTest);
            //GL.Disable(EnableCap.Blend);
            //GL.Disable(EnableCap.CullFace);
            //GL.Disable(EnableCap.DepthTest);
            //  Reset the color back to white
            GL.Disable(EnableCap.Blend);

            GL.PopMatrix();


            GL.Flush();
            glControl1.SwapBuffers();

        }

        private void DrawEdges()
        {
            GL.Begin(BeginMode.Lines);
            {
                GL.Color3(Color.DarkRed);
                GL.Vertex3(0f, 0f, 0f);
                GL.Vertex3(10f, 0f, 0f);

                GL.Color3(Color.Blue);
                GL.Vertex3(0f, 0f, 0f);
                GL.Vertex3(0f, 10f, 0f);

                GL.Color3(Color.Green);
                GL.Vertex3(0f, 0f, 0f);
                GL.Vertex3(0f, 0f, 10f);
            }
            GL.End();
            GL.Flush();
        }

        private int LoadTextures(int num_tex)
        {
            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = BTX0.GetTexture(pluginHost, tex, num_tex);
            System.Drawing.Imaging.BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp_data.Width, bmp_data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp_data.Scan0);

            bmp.UnlockBits(bmp_data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);

            return id;
        }


        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(this.ClientRectangle);
            glControl1.Invalidate();
        }

        #region Rotation methods
        private int _mouseStartX = 0;
        private int _mouseStartY = 0;
        private float angleX = 0;
        private float angleY = 0;
        private float angleXS = 0;
        private float angleYS = 0;
        private float distance = 1;
        private float distanceS = 1;
        private const float ROT_SPEED = 1f;
        private const float ZOOM_FACTOR = 500f;

        float x = 0;
        float y = 0;
        float z = 0;
        const float STEP = 0.5f;

        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs ev = (e as MouseEventArgs);
            _mouseStartX = ev.X;
            _mouseStartY = ev.Y;
        }
        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseEventArgs ev = (e as MouseEventArgs);

            angleXS = angleX;
            angleYS = angleY;
            distanceS = distance;
        }
        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs ev = (e as MouseEventArgs);
            if (ev.Button == MouseButtons.Left)
            {
                angleX = angleXS + (ev.X - _mouseStartX) * ROT_SPEED;
                angleY = angleYS + (ev.Y - _mouseStartY) * ROT_SPEED;
            }
            if (ev.Button == MouseButtons.Right)
            {
                distance = (distanceS + (ev.Y - _mouseStartY)) / ZOOM_FACTOR;
                if (distance > 3)
                    distance = 3;
                else if (distance <= 0)
                    distance = 2 / ZOOM_FACTOR;
            }
            glControl1.Invalidate();
        }
        #endregion


        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.J)
                x += STEP;
            else if (e.KeyCode == Keys.L)
                x -= STEP;
            else if (e.KeyCode == Keys.K)
                y += STEP;
            else if (e.KeyCode == Keys.I)
                y -= STEP;
            else if (e.KeyCode == Keys.U)
                z += STEP;
            else if (e.KeyCode == Keys.O)
                z -= STEP;
            else if (e.KeyCode == Keys.W)
            {
                if (pm == PolygonMode.Fill)
                    pm = PolygonMode.Line;
                else if (pm == PolygonMode.Line)
                    pm = PolygonMode.Fill;
            }

            glControl1.Invalidate();

        }

        private sBTX0 Get_BTX0()
        {
            sBTX0 btx0 = new sBTX0();
            btx0.texture = model.texture;
            btx0.file = model.filePath;
            btx0.header.offset = new uint[1];
            btx0.header.offset[0] = model.header.offset[1];

            return btx0;
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ven = new Form();
            TextureControl texCon = new TextureControl(pluginHost, tex);
            texCon.Dock = DockStyle.Fill;
            ven.Size = new Size(530, 530);
            ven.FormBorderStyle = FormBorderStyle.FixedDialog;
            ven.Controls.Add(texCon);
            ven.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = numericUpDown2.Enabled = checkBox1.Checked;
        }
    }
}
