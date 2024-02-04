using BancoChu.Domain.Entities.Base;

namespace BancoChu.Domain.Entities
{
    public sealed class MoneyTransfer : BaseEntity
    {
        internal MoneyTransfer(Guid id,
            decimal amount,
            Guid accountId,
            string description,
            string destination) : base(id)
        {
            Amount = amount;
            MadeOn = DateTime.Now;
            AccountId = accountId;
            Description = description;
            Destination = destination;
            Destination = destination;
        }

        private MoneyTransfer()
        {
        }

        public decimal Amount { get; set; }
        public DateTime MadeOn { get; set; }
        public Guid AccountId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public BankAccount BankAccount { get; set; } = default!;
    }
}