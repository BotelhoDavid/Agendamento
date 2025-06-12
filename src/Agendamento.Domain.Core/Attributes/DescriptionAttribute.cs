using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Domain.Core.Attributes
{
    public sealed class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(
            string description,
            string title = null
            )
        {
            Description = description;
            Title = title;
        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
