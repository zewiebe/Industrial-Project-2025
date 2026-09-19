using System.Collections;
using System.Windows.Forms;

/// <summary>
/// This class is an implementation of the 'IComparer' interface.
/// </summary>
public class SupplierColumnSorter : IComparer
{
    private int ColumnToSort;
    private SortOrder OrderOfSort;
    private CaseInsensitiveComparer ObjectCompare;

    public SupplierColumnSorter()
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

        compareResult = ObjectCompare.Compare(textX, textY);
        

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
