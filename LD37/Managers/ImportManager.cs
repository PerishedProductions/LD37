using LD37.Entities;
using LD37.Entities.Resources;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LD37.Managers
{
    public class ImportManager
    {
        public static ImportManager Instance { get; set; } = new ImportManager();
        private ResourceFactory resourceFactory = ResourceFactory.Instance;

        public ImportTile ImportTile { get; set; }
        public Queue<ImportOptions> ImportResourcesQueue { get; set; } = new Queue<ImportOptions>();
        public int ImportInterval { get; set; } = 5000;
        private int CurrentWaitTime = 0;

        public enum ImportOptions
        {
            Leather,
            Plastic,
            Battery
        }


        private ImportManager()
        {

        }

        public void Update(GameTime gameTime)
        {
            if (ImportResourcesQueue.Count > 0)
            {
                CurrentWaitTime += gameTime.ElapsedGameTime.Milliseconds;

                if (CurrentWaitTime >= ImportInterval)
                {
                    Import();
                    CurrentWaitTime = 0;
                }

            }
        }

        public void Import()
        {
            ImportOptions resource = ImportResourcesQueue.Dequeue();
            switch (resource)
            {
                case ImportOptions.Leather:
                    resourceFactory.CreateLeather(ImportTile.position);
                    break;
                case ImportOptions.Plastic:
                    resourceFactory.CreatePlastic(ImportTile.position);
                    break;
                case ImportOptions.Battery:
                    resourceFactory.CreateBattery(ImportTile.position);
                    break;
                default:
                    break;
            }
        }
    }
}
