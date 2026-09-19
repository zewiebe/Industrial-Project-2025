using System.Collections;
using System.Windows.Forms;

/// <summary>
/// This class is an implementation of the 'IComparer' interface.
/// </summary>
public class ContractColumnSorter : IComparer
{
    private int ColumnToSort;
    private SortOrder OrderOfSort;
    private CaseInsensitiveComparer ObjectCompare;

    public ContractColumnSorter()
    {
        ColumnToSort = 0;
        OrderOfSort = SortOrder.None;
        ObjectCompare = new CaseInsensitiveComparer();
    }

    public int Compare(object x, object y)
    {
        int compareResult;
        ListViewItem listViewX = (ListViewItem)x;
        ListViewItem listViewY = (ListViewItem)y;

        string textX = listViewX.SubItems[ColumnToSort].Text;
        string textY = listViewY.SubItems[ColumnToSort].Text;

        // Check if the column contains numeric values
        if (IsNumericColumn(ColumnToSort))
        {
            if (double.TryParse(textX, out double valueX) && double.TryParse(textY, out double valueY))
            {
                compareResult = valueX.CompareTo(valueY);
            }
            else
            {
                throw new FormatException("Column contains non-numeric values.");
            }
        }
        else if (DateTime.TryParse(textX, out DateTime dateX) && DateTime.TryParse(textY, out DateTime dateY))
        {
            compareResult = dateX.CompareTo(dateY);
        }
        else
        {
            compareResult = ObjectCompare.Compare(textX, textY);
        }
        if (OrderOfSort == SortOrder.Ascending)
        {
            return compareResult;
        }
        else if (OrderOfSort == SortOrder.Descending)
        {
            return -compareResult;
        }
        else
        {
            return 0;
        }
    }

    private bool IsNumericColumn(int columnIndex)
    {
        // Define numeric columns 
        return columnIndex == 3 || columnIndex == 4 || columnIndex == 5 || columnIndex == 6;
    }

    public int SortColumn
    {
        get { return ColumnToSort; }
        set { ColumnToSort = value; }
    }

    public SortOrder Order
    {
        get { return OrderOfSort; }
        set { OrderOfSort = value; }
    }
}
