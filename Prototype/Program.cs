using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            WatchesPrototype watches1 = new OrientWatches("classic", WatchesPrototype.MVType.Mechanical);
            WatchesPrototype prototype = watches1.Clone();
            WatchesPrototype watches2 =
                new JamesBondWatches("Omega Seamaster", WatchesPrototype.MVType.Mechanical, true);
            prototype = watches2.Clone();
        }
    }
    abstract class WatchesPrototype
    {
        public enum MVType
        {
            Mechanical,
            Digital,
        }

        public MVType MovementType;
        public string Country;
        public WatchesPrototype(string country, MVType movementType)
        {
            Country = country;
            MovementType = movementType;
        }
        public abstract WatchesPrototype Clone();
    }

    class OrientWatches : WatchesPrototype
    {
        public string Collection;

        public OrientWatches(string collection, MVType movementType)
            : base("Japan", movementType)
        {
            Collection = collection;
        }
        public override WatchesPrototype Clone()
        {
            return new OrientWatches(Collection, MovementType);
        }
    }
    
    class JamesBondWatches : WatchesPrototype
    {
        public string Title { get; }
        public bool Destroyed;

        public JamesBondWatches(string title, MVType movementType, bool destroyed = false)
            : base("Japan", movementType)
        {
            Title = title;
            Destroyed = destroyed;
        }

        void Boom()
        {
            Destroyed = true;
        }
        public override WatchesPrototype Clone()
        {
            return new JamesBondWatches(Title, MovementType, Destroyed);
        }
    }
}
