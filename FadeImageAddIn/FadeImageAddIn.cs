﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.AddIn;
using AddInView;

namespace FadeImageAddIn
{
    [AddIn("FadeImage Image Processor", Version = "1.0.0.0", Publisher = "Imaginomics",
        Description = "Inverts colors to look like a photo negative")]
    public class FadeImageAddIn : AddInView.ImageProcessorAddInView
    {
        public override void Initialize(HostObject hostObj)
        {
            throw new NotImplementedException();
        }

        public override byte[] ProcessImageBytes(byte[] pixels)
        {
            Random rand = new Random();
            int offset = rand.Next(0, 10);
            for (int i = 0; i < pixels.Length - 1 - offset; i++)
            {
                if ((i + offset) % 5 == 0)
                {
                    pixels[i] = 0;
                }
            }
            return pixels;
        }
    }
}
