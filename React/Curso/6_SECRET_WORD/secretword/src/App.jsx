//React
import { useState, useCallback, useEffect} from 'react'

//CSS
import './App.css'

//DADOS
import { wordsList } from "./data/words";

//COMPONENST
import StartScreen from './components/StartScreen'
import Game from './components/Game';
import GameOver from './components/GameOver';

const stages = [
  {id: 1, name: "start"},
  {id: 2, name: "game"},
  {id: 3, name: "end"},
];

const guessesQty = 3;

function App() {

  const [gameStage, setGameStage] = useState(stages[0].name);
  const [words] = useState(wordsList);

  const [pickedword, setPickedWord] = useState("");
  const [pickedCategory, setPickedCategory] = useState("");
  const [letters, setLetters] = useState([]);

  const [guessedLetters, setGuessedLetters] = useState([]);
  const [wrongLetters, setWrongLetters] = useState([]);
  const [guesses, setGuesses] = useState(guessesQty);
  const [score, setScore] = useState(0);


  const pickWordAndCategory = useCallback(() => {
    //pick random category
    const categories = Object.keys(words);
    const category = categories[Math.floor(Math.random() * Object.keys(categories).length)];
  
    //pick a random word
    const word = words[category][Math.floor(Math.random() * words[category].length)]
    return {word, category};
  }, [words]);
  
  // Starts the secret word game
  const startGame = useCallback(() => {

    clearLetterStates();
    const {word, category} = pickWordAndCategory();
    
    //Create an array of letters
    let wordLetters = word.split("");

    wordLetters = wordLetters.map((l) => l.toLowerCase());


    //fill states
    setPickedWord(word);
    setPickedCategory(category);
    setLetters(wordLetters);

    setGameStage(stages[1].name);
  }, [pickWordAndCategory]);

  //process the letter input
  const verifyLetter = (letter) => {
    
    const normalizedLetter = letter.toLowerCase();

    //check if letter has already been utilized
    if (guessedLetters.includes(normalizedLetter) || wrongLetters.includes(normalizedLetter)){
      return;
    }

    // push a guessedLetters or remove a guess
    if (letters.includes(normalizedLetter)){
      //adicionar elemento em um array de state
      setGuessedLetters((actualGuessedLetters) => [
        ...actualGuessedLetters, normalizedLetter
      ]);
    }
    else{
      setWrongLetters((actualWrongLetters) => [
        ...actualWrongLetters, normalizedLetter
      ]);
      setGuesses((actualGuesses) => actualGuesses - 1);
    }
  }

  const clearLetterStates = () => {
    setGuessedLetters([]);
    setWrongLetters([]);

  }

  //useEffect monitorar um dado e realizar uma função quando ouver alteração
  useEffect(() => {
    if (guesses <= 0){
      //resset all states
      clearLetterStates();
      setGameStage(stages[2].name);
    }
  }, [guesses]);

  //monitorando condição de vitoria
  useEffect(() => {
    //Set só deixa valores unicos no novo array
    const uniqueLetters = [... new Set(letters)];

    if (guessedLetters.length === uniqueLetters.length){
      setScore((actualScore) => actualScore += 100);

      //Restart game
      startGame();
    }

  }, [guessedLetters, letters, startGame]);

  // restarts the game
  const retry = () =>{
    setScore(0);
    setGuesses(guessesQty);
    setGameStage(stages[0].name);
  }

  return (
    <div className="App">
      {gameStage === "start" && <StartScreen startGame={startGame}/>}
      {gameStage === "game" && <Game 
      verifyLetter={verifyLetter}
      pickedWord={pickedword} 
      pickedCategory={pickedCategory} 
      letters={letters} 
      guessedLetters={guessedLetters}
      wrongLetters={wrongLetters}
      guesses={guesses}
      score={score}
      />}
      {gameStage === "end" && <GameOver retry={retry} score={score}/>}
    </div>
  )
}

export default App
