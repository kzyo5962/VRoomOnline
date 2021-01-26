using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vroom.Models
{
    public class ModelViewModel
    {
        public Model Model { get; set; }

        public IEnumerable<Make> Makes { get; set; }

        
    }
}
