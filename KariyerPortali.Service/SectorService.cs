using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Data.Repositories;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Service
{
    public interface ISectorService
    {
        IEnumerable<Sector> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        
        IEnumerable<Sector> GetSectors();
        Sector GetSector(int id);
        void CreateSector(Sector sector);
        void UpdateSector(Sector sector);
        void DeleteSector(Sector sector);
        void SaveSector();
    }
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository sectorRepository;
        private readonly IUnitOfWork unitOfWork;
        public SectorService(ISectorRepository sectorRepository, IUnitOfWork unitOfWork)
        {
            this.sectorRepository = sectorRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ISectorService Members
        public IEnumerable<Sector> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var sectors = sectorRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return sectors;
        }
        public IEnumerable<Sector> GetSectors()
        {
            var sectors = sectorRepository.GetAll();
            return sectors;
        }
        public Sector GetSector(int id)
        {
            var sector = sectorRepository.GetById(id);
            return sector;
        }
        public void CreateSector(Sector sector)
        {
            sectorRepository.Add(sector);
        }
        public void UpdateSector(Sector sector)
        {
            sectorRepository.Update(sector);
        }
        public void DeleteSector(Sector sector)
        {
            sectorRepository.Delete(sector);
        }
        public void SaveSector()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
