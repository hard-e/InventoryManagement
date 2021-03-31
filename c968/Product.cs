using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c968
{ 
	public class Product
	{
		public int intProductID;
		public string strName;
		public float fltPrice;
		public int intInStock;
		public int intMin;
		public int intMax;
		public BindingList<Part> lstAssociatedParts = new BindingList<Part>();

		public int getProductID()
        {
			return intProductID;
        }

		public string getName()
        {
			return strName;
        }

		public float getPrice()
        {
			return fltPrice;
        }

		public int getInStock()
        {
			return intInStock;
        }

		public int getMin()
        {
			return intMin;
        }

		public int getMax()
        {
			return intMax;
        }

		public void setProductID(int id)
        {
			intProductID = id;
        }

		public void setName(string name)
        {
			strName = name;
        }

		public void setPrice(float price)
        {
			fltPrice = price;
        }

		public void setInStock(int inStock)
        {
			intInStock = inStock;
        }

		public void setMin(int min)
        {
			intMin = min;
        }

		public void setMax(int max)
        {
			intMax = max;
        }

		public void addAssociatedPart(Part part)
        {
			lstAssociatedParts.Add(part);
        }

		public Part lookupAssociatedPart(int partID)
        {
			foreach(Part part in lstAssociatedParts)
            {
				if (part.getPartID() == partID)
				{
					return part;
				}
            }

			return null;
        }

		public void removeAssociatedPart(int index)
        {
			if (index >= 0)
            {
				lstAssociatedParts.RemoveAt(index);
            }

        }
		public BindingList<Part> getAssociatedParts()
		{
			return lstAssociatedParts;
		}

		public Product(int id, string name, float price, int inStock, int min, int max, BindingList<Part> associatedParts)
		{
			intProductID = id;
			strName = name;
			fltPrice = price;
			intInStock = inStock;
			intMin = min;
			intMax = max;
			lstAssociatedParts = associatedParts;
		}
	}
}
