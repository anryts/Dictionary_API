using System;
namespace tg_api.Modes
{
    public class Item
    {
        public Guid ID { get; init; }
        private string receipt_desciption;

        public string ItemDescription
        {
            get { return receipt_desciption; }
            set { receipt_desciption = value; }
        }


    }
}
