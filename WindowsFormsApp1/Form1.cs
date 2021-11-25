using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseLibrary;
using WindowsFormsApp1.Classes;
using static BaseLibrary.Dialogs;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly DataOperations _operations = new DataOperations();
        private BindingSource _bindingSource;
        private readonly DataTableEvents _dataTableEvents = new DataTableEvents();
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            membersGrid.AutoGenerateColumns = false;
            Height = 400;
            Width = 580;

            var dtMember = _operations.LoadMembers();
            var dtStates = _operations.LoadStates();

            // here a new primary key is assigned but may change when sent to be
            // inserted into the backend table
            dtMember.RowChanged += _dataTableEvents.RowChanged;
            dtMember.ColumnChanged += _dataTableEvents.ColumnChanged;

            // setup the source for state field values
            StateColumn.DisplayMember = "State";
            StateColumn.DataSource = dtStates;
            StateColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            _bindingSource = new BindingSource {DataSource = dtMember};

            bindingNavigator1.BindingSource = _bindingSource;

            membersGrid.DataSource = _bindingSource;

            // show current id, will be empty for new un-saved rows.
            idTextBox.DataBindings.Add("Text", _bindingSource, "id");

            // get column details for customers table
            var results = _operations.ColumnDetails("Member");

            if (_operations.IsSuccessFul)
            {

                // set column header text and hide column with no description
                foreach (var dataColumn in results)
                {
                    if (dataColumn.Visible)
                    {
                        membersGrid.Columns[$"{dataColumn.Name}Column"].HeaderText = dataColumn.Description;
                    }
                    else
                    {
                        membersGrid.Columns[$"{dataColumn.Name}Column"].Visible = false;
                    }
                }

                

                membersGrid.ExpandColumns();

                membersGrid.DataError += MembersGrid_DataError;
                membersGrid.CellValidating += MembersGrid_CellValidating;

            } 
            else
            {
                MessageBox.Show(_operations.LastExceptionMessage);
            }
        }

        private void MembersGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var cell = membersGrid[e.ColumnIndex, e.RowIndex];

            if (cell.IsInEditMode)
            {
                var control = membersGrid.EditingControl;

                if (membersGrid.Columns[e.ColumnIndex].Name == "PIN")
                {
                    if (!(int.TryParse(control.Text, out var testValue)))
                    {
                        ExceptionDialog("PIN must be a number with four digits");
                        e.Cancel = true;
                        return;
                    }
                    
                    if (testValue.ToString().Length != 4)
                    {
                        ExceptionDialog("PIN must be a number with four digits");
                        e.Cancel = true;
                    }
                }
            }

        }
        private void MembersGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ExceptionDialog($"{e.Exception.Message.Replace("for an Int32.","")} " + 
                            $"for '{membersGrid.Columns[e.ColumnIndex].Name}'\nPlease correct!");

            e.Cancel = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            int errorCount = 0;
            // clear errors
            membersGrid.Rows.Cast<DataGridViewRow>().ToList().ForEach(row => row.ErrorText = "");
            var originalTable = _bindingSource.DataTable();
            var results = originalTable.AllChanges();

            if (results.HasDeleted)
            {
                _operations.RemoveRows(results.DeletedPrimaryKeys);
            }

            if (results.HasNew)
            {
                if (results.HasNew)
                {                   
                    foreach (DataRow row in results.Added.Rows)
                    {
                        var test = row.IsValid();
                        if (test.InValid)
                        {
                            _bindingSource.Position = _bindingSource.Find("id", test.Id);
                            membersGrid.CurrentRow.ErrorText = test.Description;
                            errorCount += 1;
                        }
                    }

                    if (errorCount == 0)
                    {
                        _operations.AddRows(results.Added);
                    }
                }
            }

            if (results.HasModified)
            {
                foreach (DataRow row in results.Modified.Rows)
                {
                    var test = row.IsValid();
                    if (test.InValid)
                    {
                        _bindingSource.Position = _bindingSource.Find("id", test.Id);
                        membersGrid.CurrentRow.ErrorText = test.Description;
                        errorCount += 1;
                    }
                }

                if (errorCount == 0)
                {
                    _operations.UpdateRows(results.Modified);
                }

            }
        }

        private void getChangesButton_Click(object sender, EventArgs e)
        {
            var originalTable = _bindingSource.DataTable();
            var results = originalTable.AllChanges();

            if (results.HasDeleted)
            {
                _operations.RemoveRows(results.DeletedPrimaryKeys);
                if (!_operations.IsSuccessFul)
                {
                    ExceptionDialog($"Failed to remove records\n{_operations.LastExceptionMessage}");
                }
            }

            if (results.HasNew)
            {
                _operations.AddRows(results.Added);
            }

            if (results.HasModified)
            {
                _operations.UpdateRows(results.Modified);
            }
        }

        private void mockedAddRowButton_Click(object sender, EventArgs e)
        {
            // null 1 is the primary key which gets set in BaseLibrary.TableChanges
            // null 2 has a default value of true for the status field
            _bindingSource.DataTable().Rows.Add(null, null, "Karen","Payne","111 Apple Lane","Salem", "OR", "98888", "5555");
            _bindingSource.MoveLast();
        }

        /// <summary>
        /// By default a BindingNavigator action buttons perform actions for us,
        /// in this case Item under BindingNavigator properties, DeleteIem is set
        /// to none. This way we can prompt for removal rather than doing the actual delete
        /// where it may had been unintended.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (Question("Remove current member"))
            {
                _bindingSource.DataRow().Delete();
            }
        }
    }
}
