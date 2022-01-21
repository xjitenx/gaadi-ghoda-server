﻿using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository
{
    public interface IPartyRepository
    {
        Task<Party> Save(Party party);
        Task<Party> Get(Guid id);
        Task<List<Party>> Gets();
        Task<Party> Update(Party party);
        Task<Party> Delete(Guid id);
    }
}
