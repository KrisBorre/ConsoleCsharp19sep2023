namespace ConsolePersoon28sep2023
{
    public class Hand
    {
        public int NumberOfFingers { get; set; }

        private bool isHoldingWeapon;

        public bool IsHoldingWeapon
        {
            get { return isHoldingWeapon; }
            set { isHoldingWeapon = value; }
        }
    }
}
