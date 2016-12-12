namespace SolidPresentation.DIP.Good.Fakes
{
    using SolidPresentation.DIP.Good.Services;

    public class FakeConfirmationService : IConfirmationService
    {
        private readonly bool answerWhenQuestion;

        public FakeConfirmationService(bool answerWhenQuestion)
        {
            this.answerWhenQuestion = answerWhenQuestion;
        }

        public bool ConfirmPersonDeletion(int nbPersonToDelete)
        {
            return this.answerWhenQuestion;
        }
    }
}
