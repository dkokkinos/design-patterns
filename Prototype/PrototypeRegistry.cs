using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class PrototypeRegistry
    {
        public IntelligenceMonster IntelligenceMonsterPrototype;
        public StrengthMonster StrengthMonsterPrototype;

        public PrototypeRegistry(IntelligenceMonster intelligenceMonsterPrototype,
            StrengthMonster strengthMonsterPrototype)
        {
            IntelligenceMonsterPrototype = intelligenceMonsterPrototype;
            StrengthMonsterPrototype = strengthMonsterPrototype;
        }
    }

    public class DynamicPrototypeRegistry
    {
        private readonly Dictionary<string, Monster> _prototypes = new();

        public void Register(string key, Monster prototype)
            => _prototypes.Add(key, prototype);

        public Monster Get(string key)
            => _prototypes[key];
    }


    public class Graphics
    {
        public void Draw(Monster monster, Point position)
        {
            // draw at position
        }
    }

    public class Monster : ICloneable
    {
        public string Name { get; set; }
        public string Kind { get; set; }

        public Graphics Graphics { get; }

        public Monster(string kind)
        {
            Kind = kind;
            Graphics = new Graphics(); // time consuming functionality 
        }

        private Monster(Graphics graphics, string name, string kind)
        {
            Graphics = graphics;
            Name = name;
            Kind = kind;
        }

        public void Draw()
        {
            Graphics.Draw(this, position: new Point(10, 10));
        }

        public virtual object Clone()
        {
            // we set the already created properties
            return new Monster(Graphics, Name, Kind);
        }
    }

    public class StrengthMonster : Monster
    {
        public object ExtraPower { get; set; }

        public StrengthMonster(object extraPower) : base("Strength")
        {
            ExtraPower = extraPower;
        }

        public override object Clone()
        {
            return new StrengthMonster(this.ExtraPower);
        }
    }

    public class IntelligenceMonster : Monster
    {
        public int ManaPoints { get; set; }

        public IntelligenceMonster(int manaPoints) : base("Intelligence")
        {
            manaPoints = ManaPoints;
        }

        public override object Clone()
        {
            return new IntelligenceMonster(ManaPoints)
            {
                ManaPoints = this.ManaPoints
            };
        }
    }


    public class Configuration : ICloneable
    {
        public bool IsUserLogedIn { get; }
        public string Role { get; }
        public string ConnectionString { get; private set; }
        public string ApiKey { get; }
        public bool IsDebug { get; set; }

        public Configuration(bool isUserLogedIn, string role, string connectionString, string apiKey, bool isDebug)
        {
            IsUserLogedIn = isUserLogedIn;
            Role = role;
            ConnectionString = connectionString;
            ApiKey = apiKey;
            IsDebug = isDebug;
        }

        private Configuration(Configuration source)
        {
            IsUserLogedIn = source.IsUserLogedIn;
            Role = source.Role;
            ConnectionString = source.ConnectionString;
            ApiKey = source.ApiKey;
            IsDebug = source.IsDebug;
        }

        public void SetConnectionString(string connectionString)
            => ConnectionString = connectionString;

        public object Clone()
        {
            return new Configuration(this);
        }
    }
}
