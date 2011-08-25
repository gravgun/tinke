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
 * Programador: pleoNeX
 * 
 */
namespace Tinke.Dialog
{
    partial class FATExtract
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.groupOffset = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericOffsetLen = new System.Windows.Forms.NumericUpDown();
            this.checkOffsetBigEndian = new System.Windows.Forms.CheckBox();
            this.btnOffsetCalculate = new System.Windows.Forms.Button();
            this.groupOffsetRelative = new System.Windows.Forms.GroupBox();
            this.numericRelativeOffset = new System.Windows.Forms.NumericUpDown();
            this.radioRelativeFirstFile = new System.Windows.Forms.RadioButton();
            this.radioRelativeOffset = new System.Windows.Forms.RadioButton();
            this.groupOffsetType = new System.Windows.Forms.GroupBox();
            this.radioOffsetEnd = new System.Windows.Forms.RadioButton();
            this.radioOffsetStartEnd = new System.Windows.Forms.RadioButton();
            this.radioOffsetStartSize = new System.Windows.Forms.RadioButton();
            this.radioOffsetStart = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.numericOffsetStart = new System.Windows.Forms.NumericUpDown();
            this.groupNumFiles = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericNumFiles = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.checkNumBigEndian = new System.Windows.Forms.CheckBox();
            this.numericNumOffset = new System.Windows.Forms.NumericUpDown();
            this.btnNumCalculate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericNumLen = new System.Windows.Forms.NumericUpDown();
            this.btnAccept = new System.Windows.Forms.Button();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.btnHex = new System.Windows.Forms.Button();
            this.groupOptions.SuspendLayout();
            this.groupOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetLen)).BeginInit();
            this.groupOffsetRelative.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRelativeOffset)).BeginInit();
            this.groupOffsetType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetStart)).BeginInit();
            this.groupNumFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumLen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.groupOffset);
            this.groupOptions.Controls.Add(this.groupNumFiles);
            this.groupOptions.Location = new System.Drawing.Point(13, 13);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(492, 297);
            this.groupOptions.TabIndex = 0;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Opciones";
            // 
            // groupOffset
            // 
            this.groupOffset.Controls.Add(this.label6);
            this.groupOffset.Controls.Add(this.numericOffsetLen);
            this.groupOffset.Controls.Add(this.checkOffsetBigEndian);
            this.groupOffset.Controls.Add(this.btnOffsetCalculate);
            this.groupOffset.Controls.Add(this.groupOffsetRelative);
            this.groupOffset.Controls.Add(this.groupOffsetType);
            this.groupOffset.Controls.Add(this.label4);
            this.groupOffset.Controls.Add(this.numericOffsetStart);
            this.groupOffset.Location = new System.Drawing.Point(6, 105);
            this.groupOffset.Name = "groupOffset";
            this.groupOffset.Size = new System.Drawing.Size(477, 186);
            this.groupOffset.TabIndex = 1;
            this.groupOffset.TabStop = false;
            this.groupOffset.Text = "Offset";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tamaño offset:";
            // 
            // numericOffsetLen
            // 
            this.numericOffsetLen.Hexadecimal = true;
            this.numericOffsetLen.Location = new System.Drawing.Point(103, 46);
            this.numericOffsetLen.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericOffsetLen.Name = "numericOffsetLen";
            this.numericOffsetLen.Size = new System.Drawing.Size(76, 20);
            this.numericOffsetLen.TabIndex = 6;
            this.numericOffsetLen.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // checkOffsetBigEndian
            // 
            this.checkOffsetBigEndian.AutoSize = true;
            this.checkOffsetBigEndian.Location = new System.Drawing.Point(186, 23);
            this.checkOffsetBigEndian.Name = "checkOffsetBigEndian";
            this.checkOffsetBigEndian.Size = new System.Drawing.Size(77, 17);
            this.checkOffsetBigEndian.TabIndex = 5;
            this.checkOffsetBigEndian.Text = "Big Endian";
            this.checkOffsetBigEndian.UseVisualStyleBackColor = true;
            // 
            // btnOffsetCalculate
            // 
            this.btnOffsetCalculate.Location = new System.Drawing.Point(9, 145);
            this.btnOffsetCalculate.Name = "btnOffsetCalculate";
            this.btnOffsetCalculate.Size = new System.Drawing.Size(126, 35);
            this.btnOffsetCalculate.TabIndex = 4;
            this.btnOffsetCalculate.Text = "Leer offset";
            this.btnOffsetCalculate.UseVisualStyleBackColor = true;
            this.btnOffsetCalculate.Click += new System.EventHandler(this.btnOffsetCalculate_Click);
            // 
            // groupOffsetRelative
            // 
            this.groupOffsetRelative.Controls.Add(this.numericRelativeOffset);
            this.groupOffsetRelative.Controls.Add(this.radioRelativeFirstFile);
            this.groupOffsetRelative.Controls.Add(this.radioRelativeOffset);
            this.groupOffsetRelative.Location = new System.Drawing.Point(9, 65);
            this.groupOffsetRelative.Name = "groupOffsetRelative";
            this.groupOffsetRelative.Size = new System.Drawing.Size(256, 74);
            this.groupOffsetRelative.TabIndex = 1;
            this.groupOffsetRelative.TabStop = false;
            this.groupOffsetRelative.Text = "Offset relativo a";
            // 
            // numericRelativeOffset
            // 
            this.numericRelativeOffset.Hexadecimal = true;
            this.numericRelativeOffset.Location = new System.Drawing.Point(102, 27);
            this.numericRelativeOffset.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericRelativeOffset.Name = "numericRelativeOffset";
            this.numericRelativeOffset.Size = new System.Drawing.Size(75, 20);
            this.numericRelativeOffset.TabIndex = 1;
            // 
            // radioRelativeFirstFile
            // 
            this.radioRelativeFirstFile.AutoSize = true;
            this.radioRelativeFirstFile.Location = new System.Drawing.Point(6, 51);
            this.radioRelativeFirstFile.Name = "radioRelativeFirstFile";
            this.radioRelativeFirstFile.Size = new System.Drawing.Size(92, 17);
            this.radioRelativeFirstFile.TabIndex = 2;
            this.radioRelativeFirstFile.Text = "Primer archivo";
            this.radioRelativeFirstFile.UseVisualStyleBackColor = true;
            this.radioRelativeFirstFile.CheckedChanged += new System.EventHandler(this.radioRelativeFirstFile_CheckedChanged);
            // 
            // radioRelativeOffset
            // 
            this.radioRelativeOffset.AutoSize = true;
            this.radioRelativeOffset.Checked = true;
            this.radioRelativeOffset.Location = new System.Drawing.Point(6, 27);
            this.radioRelativeOffset.Name = "radioRelativeOffset";
            this.radioRelativeOffset.Size = new System.Drawing.Size(56, 17);
            this.radioRelativeOffset.TabIndex = 0;
            this.radioRelativeOffset.TabStop = true;
            this.radioRelativeOffset.Text = "Offset:";
            this.radioRelativeOffset.UseVisualStyleBackColor = true;
            // 
            // groupOffsetType
            // 
            this.groupOffsetType.Controls.Add(this.radioOffsetEnd);
            this.groupOffsetType.Controls.Add(this.radioOffsetStartEnd);
            this.groupOffsetType.Controls.Add(this.radioOffsetStartSize);
            this.groupOffsetType.Controls.Add(this.radioOffsetStart);
            this.groupOffsetType.Location = new System.Drawing.Point(271, 19);
            this.groupOffsetType.Name = "groupOffsetType";
            this.groupOffsetType.Size = new System.Drawing.Size(200, 120);
            this.groupOffsetType.TabIndex = 2;
            this.groupOffsetType.TabStop = false;
            this.groupOffsetType.Text = "Tipo de offset";
            // 
            // radioOffsetEnd
            // 
            this.radioOffsetEnd.AutoSize = true;
            this.radioOffsetEnd.Location = new System.Drawing.Point(23, 94);
            this.radioOffsetEnd.Name = "radioOffsetEnd";
            this.radioOffsetEnd.Size = new System.Drawing.Size(73, 17);
            this.radioOffsetEnd.TabIndex = 3;
            this.radioOffsetEnd.TabStop = true;
            this.radioOffsetEnd.Text = "End offset";
            this.radioOffsetEnd.UseVisualStyleBackColor = true;
            // 
            // radioOffsetStartEnd
            // 
            this.radioOffsetStartEnd.AutoSize = true;
            this.radioOffsetStartEnd.Location = new System.Drawing.Point(23, 48);
            this.radioOffsetStartEnd.Name = "radioOffsetStartEnd";
            this.radioOffsetStartEnd.Size = new System.Drawing.Size(135, 17);
            this.radioOffsetStartEnd.TabIndex = 1;
            this.radioOffsetStartEnd.Text = "Start offset / End offset";
            this.radioOffsetStartEnd.UseVisualStyleBackColor = true;
            // 
            // radioOffsetStartSize
            // 
            this.radioOffsetStartSize.AutoSize = true;
            this.radioOffsetStartSize.Location = new System.Drawing.Point(23, 71);
            this.radioOffsetStartSize.Name = "radioOffsetStartSize";
            this.radioOffsetStartSize.Size = new System.Drawing.Size(107, 17);
            this.radioOffsetStartSize.TabIndex = 2;
            this.radioOffsetStartSize.Text = "Start offset / Size";
            this.radioOffsetStartSize.UseVisualStyleBackColor = true;
            // 
            // radioOffsetStart
            // 
            this.radioOffsetStart.AutoSize = true;
            this.radioOffsetStart.Checked = true;
            this.radioOffsetStart.Location = new System.Drawing.Point(23, 24);
            this.radioOffsetStart.Name = "radioOffsetStart";
            this.radioOffsetStart.Size = new System.Drawing.Size(76, 17);
            this.radioOffsetStart.TabIndex = 0;
            this.radioOffsetStart.TabStop = true;
            this.radioOffsetStart.Text = "Start offset";
            this.radioOffsetStart.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Posición de inicio:";
            // 
            // numericOffsetStart
            // 
            this.numericOffsetStart.Hexadecimal = true;
            this.numericOffsetStart.Location = new System.Drawing.Point(104, 20);
            this.numericOffsetStart.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericOffsetStart.Name = "numericOffsetStart";
            this.numericOffsetStart.Size = new System.Drawing.Size(75, 20);
            this.numericOffsetStart.TabIndex = 0;
            this.numericOffsetStart.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // groupNumFiles
            // 
            this.groupNumFiles.Controls.Add(this.label7);
            this.groupNumFiles.Controls.Add(this.numericNumFiles);
            this.groupNumFiles.Controls.Add(this.label3);
            this.groupNumFiles.Controls.Add(this.checkNumBigEndian);
            this.groupNumFiles.Controls.Add(this.numericNumOffset);
            this.groupNumFiles.Controls.Add(this.btnNumCalculate);
            this.groupNumFiles.Controls.Add(this.label2);
            this.groupNumFiles.Controls.Add(this.numericNumLen);
            this.groupNumFiles.Location = new System.Drawing.Point(6, 19);
            this.groupNumFiles.Name = "groupNumFiles";
            this.groupNumFiles.Size = new System.Drawing.Size(477, 80);
            this.groupNumFiles.TabIndex = 0;
            this.groupNumFiles.TabStop = false;
            this.groupNumFiles.Text = "Número de archivos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(194, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Número de archivos:";
            // 
            // numericNumFiles
            // 
            this.numericNumFiles.Location = new System.Drawing.Point(315, 44);
            this.numericNumFiles.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericNumFiles.Name = "numericNumFiles";
            this.numericNumFiles.Size = new System.Drawing.Size(75, 20);
            this.numericNumFiles.TabIndex = 6;
            this.numericNumFiles.ValueChanged += new System.EventHandler(this.numericNumFiles_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tamaño valor:";
            // 
            // checkNumBigEndian
            // 
            this.checkNumBigEndian.AutoSize = true;
            this.checkNumBigEndian.Location = new System.Drawing.Point(197, 19);
            this.checkNumBigEndian.Name = "checkNumBigEndian";
            this.checkNumBigEndian.Size = new System.Drawing.Size(77, 17);
            this.checkNumBigEndian.TabIndex = 2;
            this.checkNumBigEndian.Text = "Big Endian";
            this.checkNumBigEndian.UseVisualStyleBackColor = true;
            // 
            // numericNumOffset
            // 
            this.numericNumOffset.Hexadecimal = true;
            this.numericNumOffset.Location = new System.Drawing.Point(104, 18);
            this.numericNumOffset.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericNumOffset.Name = "numericNumOffset";
            this.numericNumOffset.Size = new System.Drawing.Size(75, 20);
            this.numericNumOffset.TabIndex = 0;
            this.numericNumOffset.ValueChanged += new System.EventHandler(this.numericNumLen_ValueChanged);
            // 
            // btnNumCalculate
            // 
            this.btnNumCalculate.Location = new System.Drawing.Point(315, 15);
            this.btnNumCalculate.Name = "btnNumCalculate";
            this.btnNumCalculate.Size = new System.Drawing.Size(100, 23);
            this.btnNumCalculate.TabIndex = 3;
            this.btnNumCalculate.Text = "Calcular";
            this.btnNumCalculate.UseVisualStyleBackColor = true;
            this.btnNumCalculate.Click += new System.EventHandler(this.btnNumCalculate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Leer en posición:";
            // 
            // numericNumLen
            // 
            this.numericNumLen.Hexadecimal = true;
            this.numericNumLen.Location = new System.Drawing.Point(104, 44);
            this.numericNumLen.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericNumLen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNumLen.Name = "numericNumLen";
            this.numericNumLen.Size = new System.Drawing.Size(75, 20);
            this.numericNumLen.TabIndex = 1;
            this.numericNumLen.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericNumLen.ValueChanged += new System.EventHandler(this.numericNumLen_ValueChanged);
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Image = global::Tinke.Properties.Resources.accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 412);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(90, 40);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(512, 20);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(192, 290);
            this.listBoxFiles.TabIndex = 2;
            // 
            // btnHex
            // 
            this.btnHex.Location = new System.Drawing.Point(512, 319);
            this.btnHex.Name = "btnHex";
            this.btnHex.Size = new System.Drawing.Size(192, 31);
            this.btnHex.TabIndex = 3;
            this.btnHex.Text = "Visor hexadecimal";
            this.btnHex.UseVisualStyleBackColor = true;
            this.btnHex.Click += new System.EventHandler(this.btnHex_Click);
            // 
            // FATExtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(716, 464);
            this.Controls.Add(this.btnHex);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.groupOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FATExtract";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Extraer archivos";
            this.groupOptions.ResumeLayout(false);
            this.groupOffset.ResumeLayout(false);
            this.groupOffset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetLen)).EndInit();
            this.groupOffsetRelative.ResumeLayout(false);
            this.groupOffsetRelative.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRelativeOffset)).EndInit();
            this.groupOffsetType.ResumeLayout(false);
            this.groupOffsetType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetStart)).EndInit();
            this.groupNumFiles.ResumeLayout(false);
            this.groupNumFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumLen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.NumericUpDown numericNumLen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNumCalculate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericNumOffset;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button btnHex;
        private System.Windows.Forms.CheckBox checkNumBigEndian;
        private System.Windows.Forms.GroupBox groupOffset;
        private System.Windows.Forms.GroupBox groupOffsetRelative;
        private System.Windows.Forms.NumericUpDown numericRelativeOffset;
        private System.Windows.Forms.RadioButton radioRelativeFirstFile;
        private System.Windows.Forms.RadioButton radioRelativeOffset;
        private System.Windows.Forms.GroupBox groupOffsetType;
        private System.Windows.Forms.RadioButton radioOffsetStartEnd;
        private System.Windows.Forms.RadioButton radioOffsetStartSize;
        private System.Windows.Forms.RadioButton radioOffsetStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericOffsetStart;
        private System.Windows.Forms.GroupBox groupNumFiles;
        private System.Windows.Forms.Button btnOffsetCalculate;
        private System.Windows.Forms.CheckBox checkOffsetBigEndian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericOffsetLen;
        private System.Windows.Forms.RadioButton radioOffsetEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericNumFiles;
    }
}