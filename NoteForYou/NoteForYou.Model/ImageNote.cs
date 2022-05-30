using System;
using System.Collections.Generic;
using System.Text;

namespace NoteForYou.Model
{
    public class ImageNote : Note
    {
        public byte[] Image { get; set; }

        public string Icon => "icon_image";
        public string IconColor => "icon_image_color";
    }
}
