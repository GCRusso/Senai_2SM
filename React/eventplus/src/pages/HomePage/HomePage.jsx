import react from "react";
import './HomePage.css'
import Title from "../../Components/Title/Title";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";
import MainContent from "../../Components/MainContent/MainContent"


const HomePage = () => {
    return (
      
            
            <MainContent>
                <Banner />
                <VisionSection />
            </MainContent>

  
    )
}

export default HomePage;