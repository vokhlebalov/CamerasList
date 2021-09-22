using System;
using System.Collections.Generic;
using System.Text;

namespace HelloApp
{
    [Serializable]
    public class Camera
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsSoundOn { get; set; }
        public string AttachedToServer { get; set; }

        public override bool Equals(object obj)
        {
            Camera camera = obj as Camera;
            return Id == camera.Id;
        }

        public Camera()
        {

        }

        public Camera(string id, string name, bool isSoundOn, string attachedToServer)
        {
            Id = id;
            Name = name;
            IsSoundOn = isSoundOn;
            AttachedToServer = attachedToServer;
        }
    }

    
}
