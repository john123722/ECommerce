using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using ECommerce.Models;

namespace ECommerce.Data_Access_Layer
{
    public class DAL
    {
        private readonly string constring = ConfigurationManager.ConnectionStrings["StringConnection"].ToString();

        public bool Upload(AddItemModel model)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_UploadItem";
                command.Parameters.AddWithValue("@ItemName", model.ItemName);
                command.Parameters.AddWithValue("@Price", model.Price);
                command.Parameters.AddWithValue("@Category", model.Category);
                command.Parameters.AddWithValue("@Quantity", model.Quantity);
                command.Parameters.AddWithValue("@Description", model.Description);
                command.Parameters.AddWithValue("@UserId", model.UserId);
                command.Parameters.AddWithValue("@FilePath", model.FilePath);
                command.Parameters.AddWithValue("@FileName", model.FileName);
                command.Parameters.AddWithValue("@FileType", model.FileType);
                command.Parameters.AddWithValue("@FileSize", model.FileSize);
                command.Parameters.AddWithValue("@UploadDate", model.UploadDate);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public List<AddItemModel> GetItems()
        {
            List<AddItemModel> data = new List<AddItemModel>();
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_DisplayItem";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new AddItemModel
                    {
                        ItemId = (int)Convert.ToInt64(dr["ItemId"]),
                        UserId = (int)Convert.ToInt64(dr["UserId"]),
                        ItemName = (string)dr["ItemName"],
                        Price = Convert.ToDouble(dr["Price"]).ToString(),
                        Category = dr["Category"].ToString(),
                        Quantity = (int)Convert.ToInt64(dr["Quantity"]),
                        Description = dr["Description"].ToString(),
                        FileName = dr["FileName"].ToString(),
                        FileSize = (int)Convert.ToInt64(dr["FileSize"]),
                        FileType = dr["FileType"].ToString(),
                        FilePath = dr["FilePath"].ToString(),
                        UploadDate = Convert.ToDateTime(dr["UploadDate"]),
                    });

                }
                return data;
            }
        }

        public bool AddItemsToCart(int itemid, int buyerId)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_AddToCart";
                command.Parameters.AddWithValue("@ItemId", itemid);
                command.Parameters.AddWithValue("@BuyerId", buyerId);
                command.Parameters.AddWithValue("@BuyerQuantity", 1);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public List<CartModel> GetCartItems(int buyerId)
        {
            List<CartModel> data = new List<CartModel>();
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_GetCartItems";
                command.Parameters.AddWithValue("@BuyerId", buyerId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CartModel
                    {
                        ItemNo = (int)Convert.ToInt64(dr["ItemNo"]),
                        ItemId = (int)Convert.ToInt64(dr["ItemId"]),
                        ItemName = (string)dr["ItemName"],
                        Price = Convert.ToDouble(dr["Price"]).ToString(),
                        Category = dr["Category"].ToString(),
                        Quantity = (int)Convert.ToInt64(dr["Quantity"]),
                        Description = dr["Description"].ToString(),
                        BuyerId = (int)Convert.ToInt64(dr["BuyerId"]),
                        BuyerQuantity = (int)Convert.ToInt64(dr["BuyerQuantity"]),
                    });

                }
                return data;
            }
        }

        public bool GetCartItemsForEdit(int ItemNo,int buyingQuantity,int quantity)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_GetCartItemsForEdit";
                command.Parameters.AddWithValue("@ItemNo", ItemNo);
                command.Parameters.AddWithValue("@BuyerQuantity", buyingQuantity);
                command.Parameters.AddWithValue("@Quantity", quantity);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public bool RemoveItemsFromCart(int ItemNo, int Quantity)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_RemoveItemsFromCart";
                command.Parameters.AddWithValue("@ItemNo", ItemNo);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public bool BuyItems(int itemno,int quantity, int buyerId,int itemid,float price,float totalPrice)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_BuyItems";
                command.Parameters.AddWithValue("@ItemNo", itemno);
                command.Parameters.AddWithValue("@BuyerId", buyerId);
                command.Parameters.AddWithValue("@BuyerQuantity", quantity);
                command.Parameters.AddWithValue("@ItemId", itemid);
                command.Parameters.AddWithValue("@PricePerUnit", price);
                command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public List<BuyModel> GetBuyItems(int buyerId)
        {
            List<BuyModel> data = new List<BuyModel>();
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_GetBuyItems";
                command.Parameters.AddWithValue("@BuyerId", buyerId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new BuyModel
                    {
                        ItemNo = (int)Convert.ToInt64(dr["ItemNo"]),
                        ItemId = (int)Convert.ToInt64(dr["ItemId"]),
                        ItemName = (string)dr["ItemName"],
                        PricePerUnit = Convert.ToDouble(dr["PricePerUnit"]).ToString(),
                        Category = dr["Category"].ToString(),
                        Description = dr["Description"].ToString(),
                        BuyerId = (int)Convert.ToInt64(dr["BuyerId"]),
                        BuyerQuantity = (int)Convert.ToInt64(dr["BuyerQuantity"]),
                        TotalPrice = Convert.ToDouble(dr["TotalPrice"]).ToString()
                    });

                }
                return data;
            }
        }

        public List<UserModel> AuthorizeUser()
        {
            List<UserModel> data = new List<UserModel>();
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_CheckUserDetails";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new UserModel
                    {
                        UserId = (int)Convert.ToInt64(dr["UserId"]),
                        UserName = (string)dr["UserName"],
                        Password = (string)dr["Password"],
                        Seller = (int)Convert.ToInt64(dr["Seller"]),
                        UserType = (int)Convert.ToInt64(dr["UserType"])
                    });

                }
                return data;
            }
        }

        public bool AddUser(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_RegisterUser";
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Seller", user.Seller);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }


        public List<BuyModel> GetBuyReports(int userId)
        {
            List<BuyModel> data = new List<BuyModel>();
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_GetBuyReports";
                command.Parameters.AddWithValue("@UserId", userId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new BuyModel
                    {
                        ItemId = (int)Convert.ToInt64(dr["ItemId"]),
                        ItemName = (string)dr["ItemName"],
                        PricePerUnit = Convert.ToDouble(dr["PricePerUnit"]).ToString(),
                        Category = dr["Category"].ToString(),
                        BuyerQuantity = (int)Convert.ToInt64(dr["BuyerQuantity"]),
                        TotalPrice = Convert.ToDouble(dr["TotalPrice"]).ToString(),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Contact = dr["Contact"].ToString(),
                        OrderCleared = (int)Convert.ToInt64(dr["OrderClear"]),
                        BuyerId = (int)Convert.ToInt64(dr["BuyerId"])
                    });

                }
                return data;
            }
        }


        public UserModel GetUserDetails(int id)
        {
            UserModel data = null;
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_GetUserDetailsForEdit";
                command.Parameters.AddWithValue("@UserId", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    data = new UserModel
                    {
                        UserId = (int)Convert.ToInt64(dr["UserId"]),
                        Name = (string)dr["Name"],
                        UserName = dr["UserName"].ToString(),
                        Email = dr["Email"].ToString(),
                        Seller = (int)Convert.ToInt64(dr["Seller"])
                    };
                }
            }
            return data;
        }

        public bool EditUserDetails(UserModel user,int id)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_EditEcomUser";
                command.Parameters.AddWithValue("@UserId", id);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Seller", user.Seller);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public List<CategoriesModel> GetCategories()
        {
            List<CategoriesModel> data = new List<CategoriesModel>();
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_GetCategories";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CategoriesModel
                    {
                        Category = (string)dr["CategoryName"],
                        Id = (int)Convert.ToInt64(dr["CategoryId"])
                    });

                }
                return data;
            }
        }

        public List<UserModel> GetAllUserDetails()
        {
            List<UserModel> data = new List<UserModel>();
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_GetAllUserDetails";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new UserModel
                    {
                        UserId = (int)Convert.ToInt64(dr["UserId"]),
                        Name = (string)dr["Name"],
                        UserName = dr["UserName"].ToString(),
                        Email = dr["Email"].ToString(),
                        Seller = (int)Convert.ToInt64(dr["Seller"]),
                        Contact = (string)dr["Contact"]
                    });

                }
                return data;
            }
        }

        public bool AddCategories(string Category)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_AddCategories";
                command.Parameters.AddWithValue("@CategoryName", Category);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }
        public bool EditCategories(string CatName, int CatId)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_EditCategories";
                command.Parameters.AddWithValue("@CategoryName", CatName);
                command.Parameters.AddWithValue("@CategoryId", CatId);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public bool DeleteCategories(int CatId)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_DeleteCategories";
                command.Parameters.AddWithValue("@CategoryId", CatId);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public List<AddItemModel> GetItemsForEdit(int UserId)
        {
            List<AddItemModel> data = new List<AddItemModel>();
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_GetItemsForEdit";
                command.Parameters.AddWithValue("@UserId", UserId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new AddItemModel
                    {
                        ItemId = (int)Convert.ToInt64(dr["ItemId"]),
                        UserId = (int)Convert.ToInt64(dr["UserId"]),
                        ItemName = (string)dr["ItemName"],
                        Price = Convert.ToDouble(dr["Price"]).ToString(),
                        Category = dr["Category"].ToString(),
                        Quantity = (int)Convert.ToInt64(dr["Quantity"]),
                        Description = dr["Description"].ToString()
                    });

                }
                return data;
            }
        }

        public AddItemModel GetInvidualEditItem(int ItemId)
        {
            AddItemModel data = null;
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_GetInvidualEditItem";
                command.Parameters.AddWithValue("@ItemId", ItemId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    data = new AddItemModel
                    {
                        ItemId = (int)Convert.ToInt64(dr["ItemId"]),
                        UserId = (int)Convert.ToInt64(dr["UserId"]),
                        ItemName = (string)dr["ItemName"],
                        Price = Convert.ToDouble(dr["Price"]).ToString(),
                        Category = dr["Category"].ToString(),
                        Quantity = (int)Convert.ToInt64(dr["Quantity"]),
                        Description = dr["Description"].ToString()
                    };
                }
            }
            return data;
        }

        public bool EditItem(AddItemModel model,int ItemId)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_EditItem";
                command.Parameters.AddWithValue("@ItemId", ItemId);
                command.Parameters.AddWithValue("@ItemName", model.ItemName);
                command.Parameters.AddWithValue("@Price", model.Price);
                command.Parameters.AddWithValue("@Category", model.Category);
                command.Parameters.AddWithValue("@Quantity", model.Quantity);
                command.Parameters.AddWithValue("@Description", model.Description);
                command.Parameters.AddWithValue("@UserId", model.UserId);
                command.Parameters.AddWithValue("@FilePath", model.FilePath);
                command.Parameters.AddWithValue("@FileName", model.FileName);
                command.Parameters.AddWithValue("@FileType", model.FileType);
                command.Parameters.AddWithValue("@FileSize", model.FileSize);
                command.Parameters.AddWithValue("@UploadDate", model.UploadDate);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public bool ClearItemsOrder(int BuyerId, int ItemId)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_ClearItemsOrder";
                command.Parameters.AddWithValue("@BuyerId", BuyerId);
                command.Parameters.AddWithValue("@ItemId", ItemId);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }


    }
}