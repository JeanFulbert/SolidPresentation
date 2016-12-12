namespace SolidPresentation.DIP.Good.Fakes
{
    using SolidPresentation.DIP.Good.Services;

    public class FakeMessageBoxService : IMessageBoxService
    {
        private readonly bool answerWhenQuestion;

        public FakeMessageBoxService(bool answerWhenQuestion)
        {
            this.answerWhenQuestion = answerWhenQuestion;
        }

        public bool ShowQuestion(string message)
        {
            return this.answerWhenQuestion;
        }
    }
}
