using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTests : IDisposable
  {
    public void Dispose()
    {
      Category.ClearAll();
    }

    [TestMethod]
    public void CategoryConstructor_CreatesInstanceOfCategory_Category()
    {
      Category newCategory = new Category("test category");
      Assert.AreEqual(typeof(Category), newCategory.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Test Category";
      Category newCategory = new Category(name);
      string result = newCategory.Name;
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsCategoryId_Int()
    {
      string name = "Test Category";
      Category newCategory = new Category(name);
      int result = newCategory.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllCategoryObjects_CategoryList()
    {
      string nameOne = "Work";
      string nameTwo = "School";
      Category newCategoryOne = new Category(nameOne);
      Category newCategoryTwo = new Category(nameTwo);
      List<Category> newList = new List<Category> { newCategoryOne, newCategoryTwo };
      List<Category> result = Category.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectCategory_Category()
    {
      string nameOne = "Work";
      string nameTwo = "School";
      Category newCategoryOne = new Category(nameOne);
      Category newCategoryTwo = new Category(nameTwo);
      Category result = Category.Find(2);
      Assert.AreEqual(newCategoryTwo, result);
    }

    [TestMethod]
    public void AddItem_AssociatesItemWithCategory_ItemList()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      List<Item> newList = new List<Item> { newItem };
      string name = "Work";
      Category newCategory = new Category(name);
      newCategory.AddItem(newItem);
      List<Item> result = newCategory.Items;
      CollectionAssert.AreEqual(newList, result);
    }
  }
}