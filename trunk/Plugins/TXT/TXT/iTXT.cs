﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PluginInterface;

namespace TXT
{
    public partial class iTXT : UserControl
    {
        IPluginHost pluginHost;
        int id;

        public iTXT(string text, IPluginHost pluginHost, int id)
        {
            InitializeComponent();

            this.pluginHost = pluginHost;
            this.id = id;
            this.txtBox.Text = text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tempFile = Path.GetTempFileName();

            File.WriteAllText(tempFile, txtBox.Text);
            pluginHost.ChangeFile(id, tempFile);
        }
    }
}
