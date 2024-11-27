using HeinekenRobot.Models;
using HeinekenRobot.Repository.RegionFolder;
using Microsoft.EntityFrameworkCore.Internal;

namespace HeinekenRobot.Service.RegionFolder
{
    public class RegionService:IRegionService
    {
        private readonly IRegionRepository _repository;

        public RegionService(IRegionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<object>> GetAllRegionsWithLocationCount()
        {
            var regions = await _repository.GetAllRegions();

            return regions.Select(r => new
            {
                RegionId = r.RegionId,
                RegionName = r.RegionName,
                Province = r.Province,
                LocationCount = r.Locations.Count // Đếm số lượng địa điểm thuộc khu vực
            }).ToList();
        }

        public async Task AddRegion(Region region)
        {
            // Kiểm tra tính duy nhất của tên khu vực
            var existingRegion = await _repository.GetRegionByName(region.RegionName);
            if (existingRegion != null)
            {
                throw new ArgumentException("Region name must be unique.");
            }

            // Kiểm tra tính duy nhất của tỉnh thành
            var duplicateProvince = await _repository.CheckProvinceExists(region.Province);
            if (duplicateProvince)
            {
                throw new ArgumentException("Province already exists in another region.");
            }

            // Thêm khu vực mới
            await _repository.AddRegion(region);
        }
        public async Task<Region?> GetRegionById(int regionId)
        {
            return await _repository.GetRegionById(regionId);
        }

        public async Task UpdateRegion(Region updatedRegion)
        {
            var existingRegion = await _repository.GetRegionById(updatedRegion.RegionId);

            if (existingRegion == null)
            {
                throw new KeyNotFoundException("Region not found.");
            }

            // Cập nhật các thuộc tính
            existingRegion.RegionName = updatedRegion.RegionName;
            existingRegion.Province = updatedRegion.Province;
            

            await _repository.UpdateRegion(existingRegion);
        }
        public async Task<bool> DeleteRegion(int regionId)
        {
            var existingRegion = await _repository.GetRegionById(regionId);

            if (existingRegion == null)
            {
                throw new KeyNotFoundException("Region not found.");
            }

            // Kiểm tra xem khu vực có địa điểm hay dữ liệu liên kết khác không
            var isRegionUsed = await _repository.IsRegionInUse(regionId);
            if (isRegionUsed)
            {
                throw new InvalidOperationException("Cannot delete a region that has associated locations.");
            }

            await _repository.DeleteRegion(regionId);
            return true;
        }

    }
}
