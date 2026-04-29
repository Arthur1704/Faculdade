import {useState} from "react";



const ListRender = () => {

  const [list] = useState(["Arthur", "Maria"]);

  const [users, setUsers] = useState([
    {id: 1, name: "Arthur", age:20},
    {id: 2, name: "Maria", age: 21},
  ]);

  const deleteRandom = () => {
    const randomNumber = Math.floor(Math.random() * 3);

    setUsers((prevUsers) =>{
        return prevUsers.filter((user) => randomNumber !== user.id);
    })
  }

  return (
    <div>
        <ul>
            {list.map((item, index) => (
                <li key={index}>{item}</li>
            ))}
        </ul>
        <ul>
            {users.map((user) =>(
                <li key={user.id}>
                    {user.name} - {user.age}
                </li>
            ))}
        </ul>
        <button onClick={deleteRandom}>Deletar</button>
    </div>
  )
}

export default ListRender