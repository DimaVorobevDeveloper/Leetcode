namespace Leetcode.Services
{
    public class SpanExamples
    {
        public static Span<string> GetPeopleV1()
        {
            string[] people = new [] { "Tom", "Alice", "Bob" };
            Span<string> peopleSpan = new Span<string>(people);

            int[] people1 = new [] { 1, 2 };
            var peopleSpan1 = new Span<int>(people1);
            return peopleSpan;
        }

        public static Span<string> GetPeopleV2()
        {
            string[] people = new [] { "Tom", "Alice", "Bob" };
            Span<string> peopleSpan = people;
            return people;
        }
    }
}
