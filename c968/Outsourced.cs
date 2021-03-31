using System;

namespace c968
{ 
	public class Outsourced : Part
	{
		private string strCompanyName;

		public string getCompanyName()
		{
			return strCompanyName;
		}

		public void setCompanyName(string companyName)
		{
			strCompanyName = companyName;
		}

		public Outsourced(BasePart p, string companyName)
		{
			setPartID(p.intPartID);
			setName(p.strName);
			setPrice(p.fltPrice);
			setInStock(p.intInStock);
			setMin(p.intMin);
			setMax(p.intMax);
			setCompanyName(companyName);
		}
	}
}
