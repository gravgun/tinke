﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using PluginInterface;

namespace Images
{
    public class NCCG : ImageBase
    {
        sNCCG nccg;

        public NCCG(IPluginHost pluginHost, string file, int id) : base(pluginHost, file, id)
        {
        }

        public override void Read(string file)
        {
            // Image with:
            // Horizontal as tile form
            BinaryReader br = new BinaryReader(File.OpenRead(file));
            nccg = new sNCCG();

            // Nitro generic header
            nccg.generic.id = br.ReadChars(4);
            nccg.generic.endianess = br.ReadUInt16();
            nccg.generic.constant = br.ReadUInt16();
            nccg.generic.file_size = br.ReadUInt32();
            nccg.generic.header_size = br.ReadUInt16();
            nccg.generic.nSection = br.ReadUInt16();

            // CHAR section
            nccg.charS.type = br.ReadChars(4);
            nccg.charS.size = br.ReadUInt32();
            nccg.charS.width = br.ReadUInt32();
            nccg.charS.height = br.ReadUInt32();
            nccg.charS.depth = br.ReadUInt32();

            byte[][] tiles = new byte[nccg.charS.width * nccg.charS.height][];
            for (int i = 0; i < tiles.Length; i++)
            {
                if (nccg.charS.depth == 0)
                    tiles[i] = pluginHost.Bit8ToBit4(br.ReadBytes(0x20));
                else
                    tiles[i] = br.ReadBytes(0x40);
            }

            // ATTR section
            nccg.attr.type = br.ReadChars(4);
            nccg.attr.size = br.ReadUInt32();
            nccg.attr.width = br.ReadUInt32();
            nccg.attr.height = br.ReadUInt32();
            nccg.attr.unknown = br.ReadBytes((int)(nccg.attr.width * nccg.attr.height));

            // LINK section
            nccg.link.type = br.ReadChars(4);
            nccg.link.size = br.ReadUInt32();
            nccg.link.link = new String(br.ReadChars((int)nccg.link.size - 0x08));

            if (nccg.generic.nSection == 4)
            {
                // CMNT section
                nccg.cmnt.type = br.ReadChars(4);
                nccg.cmnt.size = br.ReadUInt32();
                nccg.cmnt.unknown = br.ReadBytes((int)nccg.cmnt.size - 0x08);
            }

            br.Close();

            Set_Tiles(tiles, (int)nccg.charS.width, (int)nccg.charS.height,
                (nccg.charS.depth == 0 ? ColorDepth.Depth4Bit : ColorDepth.Depth8Bit),
                TileOrder.Horizontal, false);
        }

        public override void Write_Tiles(string fileOut)
        {
            Console.WriteLine("Write Tiles - NCCG");
        }

        public struct sNCCG
        {
            public Header generic;
            public CHAR charS;
            public ATTR attr;
            public LINK link;
            public CMNT cmnt;

            public struct CHAR
            {
                public char[] type;
                public uint size;
                public uint width;
                public uint height;
                public uint depth;
            }
            public struct ATTR
            {
                public char[] type;
                public uint size;
                public uint width;
                public uint height;
                public byte[] unknown;
            }
            public struct LINK
            {
                public char[] type;
                public uint size;
                public string link;
            }
            public struct CMNT
            {
                public char[] type;
                public uint size;
                public byte[] unknown;
            }
        }
    }

}
