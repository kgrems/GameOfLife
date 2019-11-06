using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono.Game.Models
{
    abstract class BaseEntity
    {
        public uint Id { get; set; }
        public string Name { get; set; }
    }
}