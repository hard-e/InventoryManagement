using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c968
{
    public static class Inventory
    {
        public static BindingList<Product> lstProducts = new BindingList<Product>();
        public static BindingList<Part> lstAllParts = new BindingList<Part>();
        public static int CurrentPartIndex { get; set; } = -1;
        public static int CurrentProductIndex { get; set; } = -1;

        public static void addProduct(Product product)
        {
            lstProducts.Add(product);
        }

        public static bool removeProduct(int id)
        {
            Product productToRemove = lookupProduct(id);

            if (productToRemove != null)
            {
                lstProducts.Remove(productToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Product lookupProduct(int id)
        {
            foreach (Product p in lstProducts)
            {
                if (p.getProductID() == id)
                {
                    return p;
                }
            }

            return null;
        }

        public static void updateProduct(int id, Product product)
        {
            removeProduct(id);
            addProduct(product);
        }

        public static void addPart(Part part)
        {
            lstAllParts.Add(part);
        }

        public static bool deletePart(int i)
        {
            lstAllParts.RemoveAt(i);
            return true;
        }

        public static Part lookupPart(int id)
        {
            foreach (Part p in lstAllParts)
            {
                if (p.getPartID() == id)
                {
                    return p;
                }
            }

            return null;
        }

        public static void updatePart(int id, Part part)
        {
            deletePart(id);
            addPart(part);
        }

        public static int createProductID()
        {
            int highestID = 220;
            foreach (Product p in lstProducts)
            {
                if (p.getProductID() > highestID)
                    highestID = p.getProductID();
            }
            return highestID + 1;
        }

        public static int createPartID()
        {
            int highestID = 101;
            foreach (Part p in lstAllParts)
            {
                if (p.getPartID() > highestID)
                    highestID = p.getPartID();
            }
            return highestID + 1;
        }

    }
}