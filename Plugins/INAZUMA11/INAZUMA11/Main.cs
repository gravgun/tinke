﻿// ----------------------------------------------------------------------
// <copyright file="Main.cs" company="none">

// Copyright (C) 2012
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by 
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful, 
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details. 
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>. 
//
// </copyright>

// <author>pleoNeX</author>
// <email>benito356@gmail.com</email>
// <date>27/04/2012 23:53:48</date>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PluginInterface;

namespace INAZUMA11
{
    public class Main : IGamePlugin
    {
        IPluginHost pluginHost;
        string gameCode;

        public void Initialize(IPluginHost pluginHost, string gameCode)
        {
            this.gameCode = gameCode;
            this.pluginHost = pluginHost;
        }
        public bool IsCompatible()
        {
            if (gameCode == "BEBJ" || gameCode == "BOEJ" || gameCode == "BEEJ" ||
                gameCode == "YEEP" || gameCode == "YEEJ" || gameCode == "BE8J" ||
                gameCode == "BEZJ" || gameCode == "BEBP" || gameCode == "BEEP")
                    return true;

            return false;
        }

        public Format Get_Format(string fileName, byte[] magic, int id)
        {
            string ext = new string(Encoding.ASCII.GetChars(magic));

            // Pack files
            if ((fileName.ToUpper().EndsWith(".PAC_") || fileName.ToUpper().EndsWith(".PAC")) && BitConverter.ToUInt32(magic, 0) < 0x100)
                return Format.Pack;
            else if (fileName.ToUpper().EndsWith(".PKB"))
                return Format.Pack;
            else if (fileName.ToUpper().EndsWith(".PKH"))
                return Format.System;
            else if (fileName.ToUpper().EndsWith(".SPF_") && ext == "SFP\0")
                return Format.Pack;
            else if (fileName.ToUpper().EndsWith(".SPD"))
                return Format.Pack;
            else if (fileName.ToUpper().EndsWith(".SPL"))
                return Format.System;

            // Text files
            // TODO: Include more gameCodes here and in Show_Info
            switch (gameCode)
            {
                case "BEBP":
                    if (id >= 0x13F && id <= 0x161) return Format.Text;
                    if (id == 0xD8) return Format.Text;
                    if (id == 0x387) return Format.Text;
                    if (id == 0x388) return Format.Text;
                    break;
            }

            return Format.Unknown;
        }

        public sFolder Unpack(string file, int id)
        {
            if (file.ToUpper().EndsWith(".PAC_") || file.ToUpper().EndsWith(".PAC"))
                return PAC.Unpack(file);

            if (file.ToUpper().EndsWith(".SPF_"))
                return SFP.Unpack(file);

            if (file.ToUpper().EndsWith(".PKB"))
            {
                string pkh = pluginHost.Search_File(id + 1);
                if (Path.GetFileNameWithoutExtension(pkh).Substring(12) !=
                    Path.GetFileNameWithoutExtension(file).Substring(12))
                {
                    Console.WriteLine("Error searching header file");
                    return new sFolder();
                }

                return PKB.Unpack(file, pkh);
            }

            if (file.ToUpper().EndsWith(".SPD"))
            {
                string spl = pluginHost.Search_File(id + 1);
                if (Path.GetFileNameWithoutExtension(spl).Substring(12) !=
                    Path.GetFileNameWithoutExtension(file).Substring(12))
                {
                    Console.WriteLine("Error searching header file");
                    return new sFolder();
                }

                return SFP.Unpack(file, spl);
            }

            return new sFolder();
        }
        public string Pack(ref sFolder unpacked, string file, int id)
        {
            return null;
        }

        public void Read(string file, int id)
        {
        }
        public Control Show_Info(string file, int id)
        {
            switch (gameCode)
            {
                case "BEBP":
                    if (id >= 0x13F && id <= 0x161) return new SubtitlesControl(file, pluginHost, id);
                    if (id == 0xD8) return new USearchControl(file, id, pluginHost);
                    if (id == 0x387) return new BlogpostControl(file, id, pluginHost);
                    if (id == 0x388) return new BlogresControl(file, id, pluginHost);
                    break;
            }
            return new Control();
        }

    }
}
