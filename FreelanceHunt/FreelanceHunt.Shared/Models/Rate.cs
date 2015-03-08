using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FreelanceHunt.Models
{
    public class Rate : BaseModel
    {
        private byte _daysToDeliver;

        [JsonProperty("days_to_deliver")]
        public byte DaysToDeliver
        {
            get
            {
                return _daysToDeliver;
            }
            set
            {
                _daysToDeliver = value;
                OnPropertyChanged();
            }
        }
        
        private uint _amount;
        [JsonProperty("amount")]
        public uint Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }

        private string _currency_code;

        [JsonProperty("currency_code")]
        public string CurrencyCode
        {
            get
            {
                return _currency_code;
            }
            set
            {
                _currency_code = value;
                OnPropertyChanged();
            }
        }

        private byte _is_safe_project;
        [JsonProperty("is_safe_project")]
        public byte IsSafeProject
        {
            get
            {
                return _is_safe_project;
            }
            set
            {
                _is_safe_project = value;
                OnPropertyChanged();
            }
        }

        private string _comment;
        [JsonProperty("comment")]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                OnPropertyChanged();
            }
        }
    }
}
