namespace ConsolePersoon28sep2023
{
    internal class Person
    {
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Head head = new Head();
        private Leg[] legs;
        private Dictionary<string, Hand> hands = new Dictionary<string, Hand>();

        protected Leg[] Legs
        {
            get
            {
                return legs;
            }
        }

        public Person(string name, int age, int numberOfLegs = 2)
        {
            this.name = name;
            this.age = age;
            legs = new Leg[numberOfLegs];
            for (int i = 0; i < legs.Length; i++)
            {
                legs[i] = new Leg();
                legs[i].HasKnees = true;
                legs[i].Muscle = Muscularity.Very;
            }

            if (legs.Length > 0)
            {
                legs[0].LeftOfRight = Leg.LeftOrRight.Right;
                if (legs.Length > 1)
                {
                    for (int i = 1; i < legs.Length; i++)
                    {
                        legs[i].LeftOfRight = Leg.LeftOrRight.Left;
                    }
                }
            }
            Hand left = new Hand();
            left.IsHoldingWeapon = false;
            left.NumberOfFingers = 10;
            Hand right = new Hand();
            right.IsHoldingWeapon = true;
            right.NumberOfFingers = 10;
            hands.Add("left", left);
            hands.Add("right", right);
            head.HasHair = true;
        }


        public int GetNumberOfLegs()
        {
            return legs.Length;
        }

        protected Hand GetLeftHand()
        {
            return hands["left"];
        }

        protected Hand GetRightHand()
        {
            return hands["right"];
        }

        public void Run()
        {
            if (Legs.Length > 0)
            {
                foreach (Leg leg in Legs)
                {
                    if (leg.Muscle == Muscularity.Very)
                    {
                        leg.Running();
                    }
                }
            }
        }
    }
}
