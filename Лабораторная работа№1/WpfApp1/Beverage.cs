using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBuzz
{
    public abstract class Beverage
    {
        protected string description = "Unknown Beverage";

        public virtual string getDescription()
        {
            return description;
        }

        public abstract double cost();
    }

    public class Espresso : Beverage
    {
        public Espresso()
        {
            description = "Espresso";
        }

        public override double cost()
        {
            return 1.99;
        }
    }

    public class Cappuccino : Beverage
    {
        public Cappuccino()
        {
            description = "Cappuccino";
        }

        public override double cost()
        {
            return 0.89;
        }
    }

    public class Americano : Beverage
    {
        public Americano()
        {
            description = "Americano";
        }

        public override double cost()
        {
            return 1.50;
        }
    }

    public class Cocoa : Beverage
    {
        public Cocoa()
        {
            description = "Cocoa";
        }
        public override double cost()
        {
            return 2;
        }
    }
}
