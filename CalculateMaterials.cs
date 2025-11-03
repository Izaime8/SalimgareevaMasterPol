using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPolSalimgareeva
{
    public class CalculateMaterials
    {
        int CalculateMaterialsMethod(int ProductTypeID, int MaterialTypeID, int RequiredQuantity, double FirstParametr, double SecondParametr)
        {
            ProductType productType = SalimgareevaMasterPolEntities.GetContext().ProductType.Where(p => p.ProductTypeID == ProductTypeID).FirstOrDefault();
            MaterialType materialType = SalimgareevaMasterPolEntities.GetContext().MaterialType.Where(m => m.MaterialTypeID == MaterialTypeID).FirstOrDefault();


            if (ProductTypeID <= 0 || 
                MaterialTypeID <= 0 || 
                RequiredQuantity <= 0 || 
                FirstParametr <= 0 || 
                SecondParametr <= 0 ||
                productType == null ||
                materialType == null)
            {
                return -1;
            }
            double RequiredMaterialsOnProduct = FirstParametr * SecondParametr * Convert.ToDouble( productType.ProductTypeCoefficient);
            double RequiredMaterials = RequiredQuantity * RequiredMaterialsOnProduct * Convert.ToDouble(materialType.MaterialTypeDefectPersent);
            return Convert.ToInt32( Math.Ceiling(RequiredMaterials));
        }
    }
}
