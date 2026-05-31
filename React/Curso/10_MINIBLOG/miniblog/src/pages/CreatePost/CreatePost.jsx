import { useState } from "react";
import styles from "./CreatePost.module.css"
import { useInsertDocument } from "../../hooks/useInsertDocument";
import {useAuthValue} from "../../context/AuthContext"

const CreatePost = () => {
  const [title, setTitle] = useState("");
  const [image, setImage] = useState("");
  const [body, setBody] = useState("");
  const [tags, setTags] = useState([]);
  const [formError, setFormError] = useState("");

  const {user} = useAuthValue();

  const {insertDocument, response} = useInsertDocument("posts")

  const handleSubmit = (e) => {
    e.preventDefault();

    setFormError("")

    insertDocument({
      title,
      image,
      body,
      tags,
      uid: user.uid,
      createdBy: user.displayName
    })
  };



  return (
    <div className={styles.create_post}>
        <h2>Criar Post</h2>
        <p>Escreva sobre o que quiser e compartilheo seu conhecimento!!</p>
        <form onSubmit={handleSubmit}>
          <label>
            <span>Titulo:</span>
            <input 
              type="text" 
              name="title"
              placeholder="Pense em um bom titulo..."
              required
              onChange={(e) => setTitle(e.target.value)}
              value={title}
            />
          </label>
          <label>
            <span>URL da imagem:</span>
            <input 
              type="text" 
              name="image"
              placeholder="Insira uma imagem que represente o seu post!"
              required
              onChange={(e) => setImage(e.target.value)}
              value={image}
            />
          </label>
          <label>
            <span>Conteudo:</span>
            <textarea 
            name="body" 
            placeholder="Insira o conteudo do post" 
            required
            onChange={(e) => setBody(e.target.value)}
            value={body}>
            </textarea>
          </label>
          <label>
            <span>Tags:</span>
            <input 
              type="text" 
              name="tags"
              placeholder="Insira as tags separadas por virgula!"
              required
              onChange={(e) => setTags(e.target.value)}
              value={tags}
            />
          </label>        
          {!response.loading &&  <button className='btn'>Cadastrar</button>}
          {response.loading &&  <button className='btn' disabled>Aguarde...</button>}        
          {response.error && <p className='error'>{response.error}</p>}
        </form>
    </div>
  )
}

export default CreatePost