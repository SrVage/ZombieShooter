namespace Code.Abstract.Interfaces
{
	public interface IStateMachine
	{
		void EnterState<TState>() where TState : class, IState;
	}
}