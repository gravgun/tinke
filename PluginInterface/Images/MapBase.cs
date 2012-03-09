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
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace PluginInterface.Images
{
    public abstract class MapBase
    {

        #region Variables
        protected IPluginHost pluginHost;
        protected int id;
        protected string fileName;
        bool loaded;

        Byte[] original;
        int startByte;

        NTFS[] map;
        int width, height;
        bool canEdit;

        Object obj;
        #endregion

        public MapBase(IPluginHost pluginHost)
        {
            this.pluginHost = pluginHost;
        }
        public MapBase(IPluginHost pluginHost, string fileIn, int id)
        {
            this.pluginHost = pluginHost;
            this.id = id;
            this.fileName = System.IO.Path.GetFileName(fileIn);

            Read(fileIn);
        }
        public MapBase(IPluginHost pluginHost, NTFS[] mapInfo, bool editable, int width = 0, int height = 0)
        {
            this.pluginHost = pluginHost;
            Set_Map(mapInfo, editable, width, height);
        }

        public abstract void Read(string fileIn);
        public abstract void Write(string fileOut, ImageBase image, PaletteBase palette);

        public Image Get_Image(ImageBase image, PaletteBase palette)
        {
            if (image.TileForm == TileForm.Lineal)
                image.TileForm = TileForm.Horizontal;

            Byte[] tiles, tile_pal;
            tiles = Actions.Apply_Map(map, image.Tiles, out tile_pal, image.TileWidth);

            ImageBase newImage = new TestImage(pluginHost);
            newImage.Set_Tiles(tiles, image.Width, image.Height, image.ColorFormat, image.TileForm, image.CanEdit);
            newImage.TilesPalette = tile_pal;
            newImage.Zoom = image.Zoom;

            if (height != 0)
                newImage.Height = height;
            if (width != 0)
                newImage.Width = width;

            return newImage.Get_Image(palette);
        }

        public void Set_Map(NTFS[] mapInfo, bool editable, int width = 0, int height = 0)
        {
            this.map = mapInfo;
            this.canEdit = editable;
            this.width = width;
            this.height = height;

            startByte = 0;
            loaded = true;

            // Get the original byte data
            List<Byte> data = new List<byte>();
            for (int i = 0; i < map.Length; i++)
                data.AddRange(BitConverter.GetBytes(pluginHost.MapInfo(map[i])));
            original = data.ToArray();
        }

        private void Change_StartByte(int newStart)
        {
            if (newStart < 0 || newStart == startByte || newStart >= original.Length)
                return;
            startByte = newStart;

            Byte[] newData = new byte[original.Length - startByte];
            Array.Copy(original, startByte, newData, 0, newData.Length);
            map = new NTFS[newData.Length / 2];

            for (int i = 0; i < map.Length; i ++)
            {
                map[i] = pluginHost.MapInfo(BitConverter.ToUInt16(newData, i * 2));
            }
        }

        #region Properties
        public int ID
        {
            get { return id; }
        }
        public String FileName
        {
            get { return fileName; }
        }
        public bool Loaded
        {
            get { return loaded; }
        }
        public bool CanEdit
        {
            get { return canEdit; }
        }

        public int StartByte
        {
            get { return startByte; }
            set { Change_StartByte(value); }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public NTFS[] Map
        {
            get { return map; }
        }
        #endregion

    }

}
