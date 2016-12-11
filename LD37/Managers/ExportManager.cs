using LD37.Entities;
using LD37.Entities.Resources;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LD37.Managers
{
    public class ExportManager
    {
        public static ExportManager Instance { get; set; } = new ExportManager();

        public ExportTile ExportTile { get; set; }
        public Queue<Resource> ExportQueue { get; set; } = new Queue<Resource>();
        public int ExportInterval { get; set; } = 30000;
        private int CurrentWaitTime = 0;

        public void Update(GameTime gameTime)
        {
            if (ExportQueue.Count > 0)
            {
                CurrentWaitTime += gameTime.ElapsedGameTime.Milliseconds;

                if (CurrentWaitTime >= ExportInterval)
                {
                    Export();
                    CurrentWaitTime = 0;
                }

            }
        }

        public void Export()
        {
            Debug.WriteLine("Exporting resources");
            while (ExportQueue.Count > 0)
            {
                Resource resource = ExportQueue.Dequeue();
                StatManager.Instance.AddMoney((int)Math.Floor(resource.Price * 0.8f));
                Debug.WriteLine($"Resource {resource.GetType()} exported");
                resource.Active = false;

            }

        }
    }
}
