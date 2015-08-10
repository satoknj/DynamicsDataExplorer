﻿using System;
using System.Windows.Forms;
using System.Drawing;
using NUnit.Framework;

using DynamicsDataExplorer.Logic;

namespace UnitTest.Logic
{
    [TestFixture]
    class ColumnReplaceLogicTest
    {
        private ListBox _list;
        private DataGridView _grid;

        [TestCase]
        public void ColumnReplaceLogicTest_Test01()
        {
            ColumnReplaceLogic cls = new ColumnReplaceLogic(_list, _grid);

            cls.StartReplace(2);
            DoAssert("1", "2", "3");

            cls.EndReplace("item3", 0);
            DoAssert("3", "2", "1");
        }

        [TestCase]
        public void ColumnReplaceLogicTest_Test02()
        {
            ColumnReplaceLogic cls = new ColumnReplaceLogic(_list, _grid);

            cls.StartReplace(-1);
            DoAssert("1", "2", "3");
        }

        [TestCase]
        public void ColumnReplaceLogicTest_Test03()
        {
            ColumnReplaceLogic cls = new ColumnReplaceLogic(_list, _grid);

            cls.StartReplace(2);
            DoAssert("1", "2", "3");

            cls.EndReplace("item3", -1);
            DoAssert("1", "2", "3");
        }



        [TestCase]
        public void ColumnReplaceLogicTest_Test04()
        {
            ColumnReplaceLogic cls = new ColumnReplaceLogic(_list, _grid);

            cls.StartReplace(0);
            DoAssert("1", "2", "3");

            cls.EndReplace("item3", 3);
            DoAssert("1", "2", "3");
        }

        [SetUp]
        public void SetUp()
        {
            _list = new ListBox();
            _list.Items.Add("item1");
            _list.Items.Add("item2");
            _list.Items.Add("item3");

            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            col1.Name = "name1";
            col1.DataPropertyName = "prop1";
            col1.HeaderText = "header1";
            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "name2";
            col2.DataPropertyName = "prop2";
            col2.HeaderText = "header2";
            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.Name = "name3";
            col3.DataPropertyName = "prop3";
            col3.HeaderText = "header3";
            _grid = new DataGridView();
            _grid.Columns.Add(col1);
            _grid.Columns.Add(col2);
            _grid.Columns.Add(col3);
        }

        private void DoAssert(string idx1, string idx2, string idx3)
        {
            Assert.AreEqual("item" + idx1, _list.Items[0].ToString());
            Assert.AreEqual("item" + idx2, _list.Items[1].ToString());
            Assert.AreEqual("item" + idx3, _list.Items[2].ToString());

            Assert.AreEqual("name" + idx1, _grid.Columns[0].Name);
            Assert.AreEqual("prop" + idx1, _grid.Columns[0].DataPropertyName);
            Assert.AreEqual("header" + idx1, _grid.Columns[0].HeaderText);
            Assert.AreEqual("name" + idx2, _grid.Columns[1].Name);
            Assert.AreEqual("prop" + idx2, _grid.Columns[1].DataPropertyName);
            Assert.AreEqual("header" + idx2, _grid.Columns[1].HeaderText);
            Assert.AreEqual("name" + idx3, _grid.Columns[2].Name);
            Assert.AreEqual("prop" + idx3, _grid.Columns[2].DataPropertyName);
            Assert.AreEqual("header" + idx3, _grid.Columns[2].HeaderText);
        }
    }
}