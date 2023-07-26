using NUnit.Framework;
using OldPadChallenge;

namespace OldPadChallengeTests
{
    [TestFixture]
    public class ProgramTests
    {
        
        [TestCase("0#", " ")]
        [TestCase("1#", "&")]
        [TestCase("11#", "'")]
        [TestCase("111#", "(")]
        [TestCase("2#", "a")]
        [TestCase("22#", "b")]
        [TestCase("222#", "c")]
        [TestCase("3#", "d")]
        [TestCase("33#", "e")]
        [TestCase("333#", "f")]
        [TestCase("4#", "g")]
        [TestCase("44#", "h")]
        [TestCase("444#", "i")]
        [TestCase("5#", "j")]
        [TestCase("55#", "k")]
        [TestCase("555#", "l")]
        [TestCase("6#", "m")]
        [TestCase("66#", "n")]
        [TestCase("666#", "o")]
        [TestCase("7#", "p")]
        [TestCase("77#", "q")]
        [TestCase("777#", "r")]
        [TestCase("7777#", "s")]
        [TestCase("8#", "t")]
        [TestCase("88#", "u")]
        [TestCase("888#", "v")]
        [TestCase("9#", "w")]
        [TestCase("99#", "x")]
        [TestCase("999#", "y")]
        [TestCase("9999#", "z")]
        [TestCase("1112 222 3 333111#", "(acdf(")]
        [TestCase("8333527777 222 3 333111#", "tfjascdf(")]
        [TestCase("4433555 555666#", "hello")]
        [TestCase("4433555 555666#", "hello")]
        [TestCase("227*#", "b")]
        [TestCase("33#", "e")]
        public void TestOldPhonePad_SendOneOrMoreCharacter_ReturnCorrectOutput(string input, string expectedOutput)
        {
            string result = Program.OldPhonePad(input);
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [TestCase("0wq#")]
        [TestCase("amareloverdecinza12345#")]
        [TestCase("123*ik#")]
        [TestCase("-5#")]
        public void TestOldPhonePad_InputWithInvalidCharacter_ThrowException(string input)
        {
            string messageExpected = "Invalid Input!";
            var exception = Assert.Throws<ArgumentException>(() => Program.OldPhonePad(input));

            Assert.That(exception.Message, Is.EqualTo(messageExpected));
        }
        [TestCase("0wq")]
        [TestCase("amareloverdecinza12345")]
        [TestCase("-5")]
        [TestCase("7777")]
        [TestCase("8")]
        [TestCase("88")]
        [TestCase("1112 222 3 333111")]
        public void TestOldPhonePad_InputWithoutSendComand_ThrowException(string input)
        {
            string messageExpected = "Without send command!";
            var exception = Assert.Throws<ArgumentException>(() => Program.OldPhonePad(input));

            Assert.That(exception.Message, Is.EqualTo(messageExpected));
        }
        [TestCase(" ")]
        [TestCase("#*#*")]
        [TestCase("*")]
        [TestCase("#")]
        public void TestOldPhonePad_InputNullOrEmpty_ThrowException(string input)
        {
            string messageExpected = "Input null or Empty!";
            var exception = Assert.Throws<ArgumentException>(() => Program.OldPhonePad(input));

            Assert.That(exception.Message, Is.EqualTo(messageExpected));
        }
    }
}
