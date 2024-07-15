namespace Shop.Module.Orders.Models
{
    public enum RefundStatus
    {
        WaitRefund = 0,

        RefundOk = 10,

        RefundCancel = 20,

        Close = 30,

        RefundFrozen = 40
    }
}