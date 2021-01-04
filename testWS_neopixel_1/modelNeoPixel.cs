using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace testWS_neopixel_1
{
    class modelNeoPixel
    {
        private uint luminosite;
        private uint vitesse;
        private ObservableCollection<string> modes;
        private uint modeActif;

        public uint Luminosite
        {
            get { return luminosite; }
            set { luminosite = value; }
        }
        public uint Vitesse
        {
            get { return vitesse; }
            set { vitesse = value; }
        }
        public ObservableCollection<string> Modes 
        {
            get { return modes; }
            set { modes = value; }
        }
        public uint ModeActif
        {
            get { return modeActif; }
            set { modeActif = value; }
        }

    }
}
