﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PluginInterface;

namespace NINOKUNI
{
    public class Main : IGamePlugin
    {
        IPluginHost pluginHost;
        String gameCode;

        public void Initialize(IPluginHost pluginHost, string gameCode)
        {
            this.pluginHost = pluginHost;
            this.gameCode = gameCode;
        }
        public bool IsCompatible()
        {
            if (gameCode == "B2KJ")
                return true;

            return false;
        }

        public Format Get_Format(string fileName, byte[] magic, int id)
        {
            String ext = new String(Encoding.ASCII.GetChars(magic));
            uint exti = BitConverter.ToUInt32(magic, 0);

            if (ext == "NPCK" || ext == "KPCN")
                return Format.Pack;
            else if (BitConverter.ToUInt32(magic, 0) == 0x001C080A)
                return Format.Text;
            else if (magic[0] == 0x42 && magic[1] == 0x4D && fileName.ToUpper().StartsWith("EDDN")) // BMP image
                return Format.FullImage;
            else if (exti == 0x001F080A || exti == 0x0019090A)
                return Format.Script;
            else if (id == 0xFF2)
                return Format.Text;
            else if (id == 0xFF4)
                return Format.Text;
            else if (id == 0xF76)
                return Format.Text;

            return Format.Unknown;
        }

        public void Read(string file, int id)
        {
        }
        public System.Windows.Forms.Control Show_Info(string file, int id)
        {
            if (file.ToUpper().EndsWith(".SQ"))
                return new SQcontrol(pluginHost, file, id);
            else if (Path.GetFileName(file).Contains("eddn"))
                return new BMPControl(file, id, pluginHost);
            else if (id == 0xFF2)
                return new ScenarioText(file);
            else if (id == 0xFF4)
                return new SystemText(file, id, pluginHost);
            else if (id == 0xF76)
                return new MQuestText(pluginHost, file, id);

            return new System.Windows.Forms.Control();
        }

        public String Pack(ref sFolder unpacked, string file, int id)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(file));
            string ext = new String(br.ReadChars(4));
            br.Close();

            if (ext == "NPCK")
            {
                string fileOut = pluginHost.Get_TempFolder() + System.IO.Path.DirectorySeparatorChar +
                    "pack_" + System.IO.Path.GetFileName(file);
                
                NPCK.Pack(fileOut, ref unpacked, pluginHost);
                return fileOut;
            }
            else if (ext == "KPCN")
            {
                string fileOut = pluginHost.Get_TempFolder() + System.IO.Path.DirectorySeparatorChar +
                    "pack_" + System.IO.Path.GetFileName(file);

                KPCN.Pack(fileOut, file, ref unpacked, pluginHost);
                return fileOut;
            }

            return null;
        }
        public sFolder Unpack(string file, int id)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(file));
            string ext = new String(br.ReadChars(4));
            br.Close();

            if (ext == "NPCK")
                return NPCK.Unpack(file, pluginHost);
            else if (ext == "KPCN")
                return KPCN.Unpack(file, pluginHost); 

            return new sFolder();
        }
    }
}
