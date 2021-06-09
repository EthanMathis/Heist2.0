namespace Heist2
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public bool IsSecure { get; }

        public Bank(int cash, int alarm, int vault, int guard)
        {
            CashOnHand = cash;
            AlarmScore = alarm;
            VaultScore = vault;
            SecurityGuardScore = guard;
            // IsSecure = true;

            if (AlarmScore <= 0 ||
                VaultScore <= 0 ||
                SecurityGuardScore <= 0)
            {
                IsSecure = false;
            }
            else
            {
                IsSecure = true;
            }
        }
    }
}