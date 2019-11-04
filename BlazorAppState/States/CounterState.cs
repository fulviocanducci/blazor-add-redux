using BlazorState;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace BlazorAppState.States
{
    public class CounterState: State<CounterState>
    {
        #region State
        public int Count { get; set; }

        public override void Initialize()
        {
            Count = 0;
        }
        #endregion

        #region Action
        public class IncrementCountAction : IAction
        {
            public int Amount { get; set; } = 1;
        }
        public class DecrementCountAction: IAction 
        {
            public int Amount { get; set; } = 1;
        }
        #endregion

        #region Handler
        public class IncrementCountHandler : ActionHandler<IncrementCountAction>
        {
            public CounterState CounterState => Store.GetState<CounterState>();
            public IncrementCountHandler(IStore store) 
                : base(store) { }            
            public override Task<Unit> Handle(IncrementCountAction incrementCountAction, CancellationToken cancellationToken)
            {
                CounterState.Count = CounterState.Count + incrementCountAction.Amount;
                return Unit.Task;
            }
        }
        public class DecrementCountHandler : ActionHandler<DecrementCountAction>
        {
            public CounterState CounterState => Store.GetState<CounterState>();
            public DecrementCountHandler(IStore store)
                : base(store) { }
            public override Task<Unit> Handle(DecrementCountAction decrementCountAction, CancellationToken cancellationToken)
            {
                CounterState.Count = CounterState.Count - decrementCountAction.Amount;
                return Unit.Task;
            }
        }
        #endregion
    }
}
