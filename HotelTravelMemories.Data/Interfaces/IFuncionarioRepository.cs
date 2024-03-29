﻿using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Data.Interfaces
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        bool AlterarStatus(int id, bool ativar);
    }
}
