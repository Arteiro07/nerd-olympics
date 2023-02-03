import axios from 'axios'
import style  from "./competitions.module.scss";
import { User } from '../types';
import Competition from './Competition';
import { CompetitionDto } from '../types';

export default async function page() {

  //get a list of competitions from the back end
    const res = await axios.get(`https://apim-nerd-olympics-dev.azure-api.net/competitions`);
    //console.log(res);
    
      return (
        <div className={style.container}>
          {res.data.map((competition:CompetitionDto)=>(
            <h1>
              <Competition
                key={competition.id}
                {...competition}
              />
            </h1>
          ))}
        </div>
      )
}

