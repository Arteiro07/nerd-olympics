import axios from 'axios'
import React from 'react'
import Image from 'next/image';
import { NextPageContext } from 'next';

interface MyPageContext extends NextPageContext {
  params: {
    player: string;
  };
}
export default async function page({params}: MyPageContext) {
    const res = await axios.get(`https://dummyjson.com/users/${params.player}`);

    return(
        <div className='playerCard'>
            <>
                <Image
                    src={res.data.image}
                    alt="player"
                    height={300}
                    width={300}
                />
            </>
            {res.data.firstName}
            {res.data.lastName}  
            {res.data.age}  
            {res.data.gender}  
            {res.data.phone}  
            {res.data.email}
        </div>
    )  
}