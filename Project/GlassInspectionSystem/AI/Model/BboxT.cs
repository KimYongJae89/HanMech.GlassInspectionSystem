using System;

namespace MechAI.Model
{
    internal struct BboxT
    {
        public UInt32 x, y, w, h;
        public float prob;
        public UInt32 obj_id;
        public UInt32 track_id;
        public UInt32 frames_counter;
    };
}
