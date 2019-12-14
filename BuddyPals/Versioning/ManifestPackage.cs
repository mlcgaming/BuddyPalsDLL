﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyPals.Versioning
{
    public class ManifestPackage
    {
        public bool Forced { get; private set; }
        public List<string> Files { get; private set; }

        public ManifestPackage(bool isForced, List<string> files)
        {
            Forced = isForced;
            if(files.Count > 0)
            {
                Files = new List<string>(files);
            }
            else
            {
                Files = new List<string>();
            }
        }
    }
}
