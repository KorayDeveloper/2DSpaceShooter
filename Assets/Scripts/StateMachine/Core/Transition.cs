public class Transition
{
    public Condition Condition { get; set; }
    public State TrueState { get; set; }
    public State FalseState { get; set; }

    public Transition(Condition condition, State trueState, State falseState)
    {
        Condition = condition;
        TrueState = trueState;
        FalseState = falseState;
    }
}