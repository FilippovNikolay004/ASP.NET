﻿using Soccer.BLL.DTO;

namespace Soccer.BLL.Interfaces
{
    public interface ITeamService 
    {
        Task CreateTeam(TeamDTO teamDto);
        Task UpdateTeam(TeamDTO teamDto);
        Task DeleteTeam(int id);
        Task<TeamDTO> GetTeam(int id);
        Task<IEnumerable<TeamDTO>> GetTeams();
    }
}
