﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginInterface;

namespace Tinke.Dialog
{
    public partial class SelectFile : Form
    {
       sFile[] files;

        public SelectFile()
        {
            InitializeComponent();
        }
        public SelectFile(sFile[] files)
        {
            InitializeComponent();

            this.files = files;

            for (int i = 0; i < files.Length; i++)
            {
                String text = "0x" + files[i].id.ToString("x") + " - ";
                text += (String)files[i].tag + '/' + files[i].name;
                listFiles.Items.Add(text);
            }
        }

        public sFile SelectedFile
        {
            get { return files[listFiles.SelectedIndex]; }
        }
    }
}
